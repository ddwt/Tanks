using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.OleDb;
using MySql;
using MySql.Data.MySqlClient;
using System;


public class Connect : MonoBehaviour {

    public static MySqlConnection dbConnection;
    public static string connectionString = "Database=tank;Data Source=localhost;User Id=root;Password=root;port=3306";

    public void OpenSqlConnection (string connectionString) {
        dbConnection = new MySqlConnection(connectionString);
        dbConnection.Open();
    }

    //关闭数据库连接
    public void CloseConnection() {
        if (dbConnection != null) {
            dbConnection.Close();
            dbConnection.Dispose();
            dbConnection = null;
        }
    }

    //保存数据
    public DataSet GetDataSet(string sqlString) {
        DataSet ds = new DataSet();
        try {
            //用于检索和保存数据
            //Fill(填充)能改变DataSet中的数据以便于数据源中数据匹配
            //Update(更新)能改变数据源中的数据以便于DataSet中的数据匹配

            MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
            da.Fill(ds);

        } catch (Exception ee) {
            throw new Exception("SQL:" + sqlString + "\n" + ee.Message.ToString());
        }
        return ds;
    }

    //增 insert
    public void Add(string command) {
        OpenSqlConnection(connectionString);
        GetDataSet(command);
        CloseConnection();
    }

    //删 delete
    public void Delete(string command) {
        OpenSqlConnection(connectionString);
        GetDataSet(command);
        CloseConnection();
    }

    //改 update
    public void UpdateTable(string command) {
        OpenSqlConnection(connectionString);
        GetDataSet(command);
        CloseConnection();

    }

    //查 select
    public string Select(string command) {
        string temp = null;
        OpenSqlConnection(connectionString);
        MySqlCommand mysqlcommand = new MySqlCommand(command, dbConnection);
        MySqlDataAdapter adatper = new MySqlDataAdapter(mysqlcommand);
        DataSet ds = new DataSet();
        adatper.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
            temp = ds.Tables[0].Rows[i][0].ToString(); //123456 读的是最后一列的字段
        }
        return temp;
    }
}
