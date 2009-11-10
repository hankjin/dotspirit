using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;

namespace Spirit.Plugin
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DB
    {
        #region 工厂方法，指出采用XMLDB实现
        private static DB db = new XmlDB();
        public static DB GetDB()
        {
            return db;
        }
        #endregion 工厂方法
        
        private Dictionary<string, DBTable> tables = new Dictionary<string, DBTable>();
        
        #region 数据库操作
        /// <summary>
        /// 根据名称获取表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DBTable GetTable(string name)
        {
            if (!tables.Keys.Contains(name))
                this.tables.Add(name, new DBTable(name));
            return this.tables[name];
        }
        /// <summary>
        /// 获取所有数据表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, DBTable> GetTables()
        {
            return this.tables;
        }
        #endregion 数据库操作

        #region 持久序列化方法
        /// <summary>
        /// 从文件中加载数据
        /// </summary>
        /// <param name="dbFile"></param>
        /// <returns></returns>
        public virtual DB Load(String dbFile)
        {
            return new DB();
        }
        /// <summary>
        /// 保存到文件中
        /// </summary>
        /// <param name="dbFile"></param>
        public virtual void Save(String dbFile)
        {
        }
        #endregion 持久序列化方法
    }
    /// <summary>
    /// 数据表
    /// </summary>
    public class DBTable : List<DBRecord>
    {
        public string Name { get; set; }
        public DBTable(String name)
        {
            this.Name = name;
        }
    }
    /// <summary>
    /// 数据记录
    /// </summary>
    public class DBRecord :Dictionary<string, string>
    {
        public DBRecord()
        {
        }
        /// <summary>
        /// 根据对象构造DBRecord
        /// </summary>
        /// <param name="obj"></param>
        public DBRecord(object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                this.Add(pi.Name, pi.GetValue(obj, null) as string);
            }
        }
        /// <summary>
        /// 根据DBRecord构造对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ToObject<T>()
        {
            //创建实例
            T obj = System.Activator.CreateInstance<T>();
            //获取类型
            Type type = typeof(T);
            //设置属性
            foreach (PropertyInfo pi in type.GetProperties())
            {
                pi.SetValue(obj, this[pi.Name], null);
            }
            return obj;
        }
    }
    /// <summary>
    /// XML数据存储
    /// </summary>
    public class XmlDB : DB
    {
        private DataSet ds = new DataSet();
        /// <summary>
        /// 从文件中加载数据
        /// </summary>
        /// <param name="dbFile"></param>
        /// <returns></returns>
        public override DB Load(string dbFile)
        {
            if (File.Exists(dbFile))
            {
                //首先加载到DataSet
                ds.ReadXml(dbFile);
                foreach (DataTable table in ds.Tables)
                {
                    DBTable xtable = this.GetTable(table.TableName);
                    foreach (DataRow row in table.Rows)
                    {
                        DBRecord record = new DBRecord();
                        foreach (DataColumn column in table.Columns)
                        {
                            record[column.ColumnName] = row[column.ColumnName] as string;
                        }
                        xtable.Add(record);
                    }
                }
            }
            return this;
        }
        public override void Save(string dbFile)
        {
            /**
             */
            ds.Clear();
            foreach (DBTable xtable in this.GetTables().Values)
            {
                //创建Table
                DataTable table = new DataTable(xtable.Name);
                //设置Columns
                foreach (string key in xtable[0].Keys)
                {
                    table.Columns.Add(new DataColumn(key));
                }
                //添加Rows
                foreach (DBRecord record in xtable)
                {
                    DataRow row = table.NewRow();
                    //设置Row的字段
                    foreach (KeyValuePair<string, string> item in record)
                    {
                        row[item.Key] = item.Value;
                    }
                    table.Rows.Add(row);//NOTE, if NewRow, need Add again?
                }
                //添加Table
                ds.Tables.Add(table);
            }
            ds.WriteXml(dbFile);
        }
    }
}
