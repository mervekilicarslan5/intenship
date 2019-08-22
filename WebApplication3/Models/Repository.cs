using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data.Entity;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Configuration;

namespace WebApplication3.Models
{
    public class Repository : IRepository<Student>
    {
        public bool Add(Student entity, out Student Added)
        {
            //take the string from Web.config
           // var Added = new Student() ;

            string connStr = ConfigurationManager.ConnectionStrings["LocalString"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                var cmd = new MySqlCommand();
                //preapare queries
                cmd.CommandText = "Insert into studentlist values (0, @Name, @LastName, @Department, @Advisor)";
                System.Diagnostics.Debug.WriteLine("My name is" + entity.s_name);
                //Using: ensures that Dispose is called even if an execution occurs while calling the methods
                //It is the same as the try catch if you call an dispose method in finally clause
                //use placeholders to be faster and protect aganist SQL Injection attacks
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Name", entity.s_name);
                cmd.Parameters.AddWithValue("@LastName", entity.s_surname);
                cmd.Parameters.AddWithValue("@Department", entity.deparment);
                cmd.Parameters.AddWithValue("@Advisor", entity.advisor);
                cmd.ExecuteNonQuery(); //since there is no return
                conn.Close();
              }
            Added = GetByDetail(entity.s_name, entity.s_surname);
            if (Added != null)
                return true;
            else
                return false;
        }
        public void Delete(int id)
        {

            string connStr = ConfigurationManager.ConnectionStrings["LocalString"].ConnectionString;
            using (var conn = new MySqlConnection(connStr))
            {
                var cmd = new MySqlCommand();
                cmd.CommandText = "DELETE FROM studentlist where s_id = @myId ";
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@myId", id);
                cmd.ExecuteNonQuery(); //since there is no return
                conn.Close();
            }
             
        }

        public void Edit(Student entity)
        {

            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LocalString"].ConnectionString;
           
            using (var conn = new MySqlConnection(connStr))
            {

                var cmd = new MySqlCommand();
                //preapare queries
                cmd.CommandText = "Select s_id,s_name, s_surname, deparment, advisor from studentlist WHERE s_id= @myId";
                // System.Diagnostics.Debug.WriteLine("My name is" + entity.s_name);
                //Using: ensures that Dispose is called even if an execution occurs while calling the methods
                //It is the same as the try catch if you call an dispose method in finally clause
                //use placeholders to be faster and protect aganist SQL Injection attacks
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@myId", id);
                
                MySqlDataReader mylist = cmd.ExecuteReader();
                while (mylist.Read())
                {
                    var specialStudent = (new Student()
                    {
                        s_id = Convert.ToInt32(mylist[0]),
                        s_name = mylist[1].ToString(),
                        s_surname = mylist[2].ToString(),
                        deparment = mylist[3].ToString(),
                        advisor = mylist[4].ToString()
                    });

                    cmd.ExecuteReader();
                    conn.Close();
                    return specialStudent;
                } }
            return null;
        }
        //throw new NotImplementedException();

        public Student GetByDetail(string name, string surname)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LocalString"].ConnectionString;

            using (var conn = new MySqlConnection(connStr))
            {

                var cmd = new MySqlCommand();
                //preapare queries
                cmd.CommandText = "Select s_id from studentlist WHERE s_name= @myName and s_surname=@last";
                // System.Diagnostics.Debug.WriteLine("My name is" + entity.s_name);
                //Using: ensures that Dispose is called even if an execution occurs while calling the methods
                //It is the same as the try catch if you call an dispose method in finally clause
                //use placeholders to be faster and protect aganist SQL Injection attacks
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@myName", name);
                cmd.Parameters.AddWithValue("@last", surname);

                MySqlDataReader mylist = cmd.ExecuteReader();
                while (mylist.Read())
                {
                    var specialStudent = (new Student()
                    {
                        s_id = Convert.ToInt32(mylist[0]),
                        s_name = mylist[1].ToString(),
                        s_surname = mylist[2].ToString(),
                        deparment = mylist[3].ToString(),
                        advisor = mylist[4].ToString()
                    });

                    cmd.ExecuteReader();
                    conn.Close();
                    return specialStudent;
                }
            }
            return null;
        }
        public IEnumerable<Student> List()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["LocalString"].ConnectionString;
            var allStudents = new List<Student>();
            using (var conn = new MySqlConnection(connStr))
            {
                var cmd = new MySqlCommand();
                //preapare queries
                cmd.CommandText = "Select * from studentlist";
                // System.Diagnostics.Debug.WriteLine("My name is" + entity.s_name);
                //Using: ensures that Dispose is called even if an execution occurs while calling the methods
                //It is the same as the try catch if you call an dispose method in finally clause
                //use placeholders to be faster and protect aganist SQL Injection attacks
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader mylist = cmd.ExecuteReader(); //since there is no return

                while (mylist.Read())
                {
                    allStudents.Add(new Student()
                    {
                        s_id = Convert.ToInt32(mylist[0]),
                        s_name = mylist[1].ToString(),
                        s_surname = mylist[2].ToString(),
                        deparment = mylist[3].ToString(),
                        advisor = mylist[4].ToString()
                    });
                }
                conn.Close();
            }
            return allStudents;
        }

    }
}