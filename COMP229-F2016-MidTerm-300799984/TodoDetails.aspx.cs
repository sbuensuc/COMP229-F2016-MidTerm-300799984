using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP229_F2016_MidTerm_300799984.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/*Author: Sam Buensuceso
*   Student#:300799984
*   Date Modified:Oct19,2016
*/

namespace COMP229_F2016_MidTerm_300799984
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }

        protected void GetTodo()
        {
            
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            
            using (TodoContext db = new TodoContext())
            {
                
                Todo updatedTodo = (from todo in db.Todos
                                          where todo.TodoID == TodoID
                                          select todo).FirstOrDefault();

                
                if (updatedTodo != null)
                {
                    TodoDescriptionTextbox.Text = updatedTodo.TodoDescription;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;

                    if(updatedTodo.Completed == true)
                    {
                        CompletedCheckBox.Checked = true;
                    }
                    
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoContext db = new TodoContext())
            {
                

                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) 
                {
                    
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                   
                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == TodoID
                                  select todo).FirstOrDefault();
                }

                
                newTodo.TodoDescription = TodoDescriptionTextbox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;

                if(CompletedCheckBox.Checked == true)
                {
                    newTodo.Completed = true;
                }
                else
                {
                    newTodo.Completed = false;
                }
               

                

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                
                db.SaveChanges();

               
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}