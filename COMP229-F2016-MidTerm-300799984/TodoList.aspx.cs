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
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetTodos();
        }

        private void GetTodos()
        {
            
            using (TodoContext db = new TodoContext())
            {
                

                
                var Todos = (from allTodos in db.Todos
                                select allTodos);

                
                TodoGridView.DataSource = Todos.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int selectedRow = e.RowIndex;

            
            int StudentID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);

            
            using (TodoContext db = new TodoContext())
            {
                
                Todo deletedTodo = (from todoRecords in db.Todos
                                          where todoRecords.TodoID == StudentID
                                          select todoRecords).FirstOrDefault();

                
                db.Todos.Remove(deletedTodo);

                
                db.SaveChanges();

                
                this.GetTodos();
            }
        }
    }
}