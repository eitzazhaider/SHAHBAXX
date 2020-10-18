using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //Basic Route 
    [RoutePrefix("Api/Student")]
    public class shabazController : ApiController
    {
        //Create Object Named As DB For Database ASEntities 
        ASEntities DB = new  ASEntities();

        //Route For AddStudent Function
        [Route("Addstudent")]
        [HttpPost]//Shows Request Type Is Post
        public string Addstudent(Todoitem st)//Function For Adding Or Inserting New Record
        {
            //Use Try Catch To Identify & Handle Exceptions/Error 
            try
            {

                //Create Objcet For Database Table Named As ToDoContext 
                ToDoContext sm = new ToDoContext();
                //Adding/Inserting Values To Database
                //Adding Or Inserting  Name
                sm.Name = st.Name;
                //Adding Or Inserting  Iscomplete
                sm.IsComplete = st.IsComplete;
                //Adding Or Inserting  Complete Record Row To Database Table
                DB.ToDoContexts.Add(sm);
                //Save Changes Means Adding Row Perfectly In Database Table
                DB.SaveChanges();
                //Return Suucessfull Message Indicates Our New Record Is Inserted 
                return "Added Successfull";



            }
            //If Some Exception/Error Occur Then Catch Handle That
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            //Return Error Message Indicates Our New Record Is Not Inserted 
            return "Error During Adding Record.";


        }



        //Route For Update Student Function
        [Route("Updatestudent")]
        [HttpPut]//Shows Request Type Is Put
        public string Updatestudent(Todoitem st)
        {
            //Use Try Catch To Identify & Handle Exceptions/Error 
            try
            {
                //Searching & Hold Record Of Already Existed Student In Obj Variable  
                var obj = DB.ToDoContexts.Where(x => x.Id == st.Id).ToList().FirstOrDefault();
                if (obj.Id > 0)
                {

                    //Setting Or Updating Student Record 
                    //Updateing Name Of Student
                    obj.Name = st.Name;
                    //Updateing Iscomplete Status  Of Student
                    obj.IsComplete = st.IsComplete;
                    //Save Changes In Database Table Or In Database
                    DB.SaveChanges();
                    //Return Success Message Indicates Our New Record Is Updated
                    return "Updation Successfull";
                }

            }
            //Handling Exceptions Function 
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            //Return Error Message Indicates Our New Record Is Not Updated
            return "Error During Updating Record.";


        }

        //Route For Getting All Students Records
        [Route("Studentdetails")]
        [HttpGet]//Shows Request Type Is Get
        public object Studentdetails()//Function For Returning All Student Records
        {
            //Get All Student Records In Object 
            var a = DB.ToDoContexts.ToList();
            //Return All Student Records
            return a;
        }
        //Route For Getting All Student Record By Id
        [Route("StudentdetailById")]
        [HttpGet]//Shows Request Type Is Get
        public object StudentdetailById(int id)//Function For Returning Specific  Student Record 
        {
            //Searching For Specific Stuent Record & Get It In Object Named As Object
            var obj = DB.ToDoContexts.Where(x => x.Id == id).ToList().FirstOrDefault();
            //Return Specific Student Record
            return obj;
        }
        //Route For Deleting  All Student Record By Id
        [Route("Deletestudent")]
        [HttpDelete]//Shows Request Type Is Delete
        public string Deletestudent(int id)//Function For Deleting Specific  Student Record 
        {
            //Try For Throwing Exceptions/Errors
            try
            {   //Search Record For Specific Student From Database Table Named As ToDoContext
                var obj = DB.ToDoContexts.Where(x => x.Id == id).ToList().FirstOrDefault();
                //Remove Student Record From Database Table Named As ToDoContext
                DB.ToDoContexts.Remove(obj);
                //Save Changes
                DB.SaveChanges();
                //Return Success Message If Record Deleted
                return "Deleted Successfull.";
            }
            //Function For Handling Exceptions/Errors
            catch (Exception e)
            {

            }
            // Return Error Message If Record  Not Deleted
            return "Fail To Delete";
        }
    
}
}
