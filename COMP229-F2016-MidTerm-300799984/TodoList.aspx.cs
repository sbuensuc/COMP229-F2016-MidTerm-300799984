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
            if (!IsPostBack)
            {
                Session["SortColumn"] = "TodoDescription";
                Session["SortDirection"] = "ASC";
                this.GetTodos();
            }
        }

        private void GetTodos()
        {
            
            using (TodoContext db = new TodoContext())
            {

                string SortString = Session["SortColumn"].ToString() + " " +
                    Session["SortDirection"].ToString();

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

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           TodoGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            
            this.GetTodos();
        }

        protected void TodoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            TodoGridView.PageIndex = e.NewPageIndex;

            
            this.GetTodos();
        }

        protected void TodoGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            
            Session["SortColumn"] = e.SortExpression;

            
            this.GetTodos();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < TodoGridView.Columns.Count - 1; index++)
                    {
                        if (TodoGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
    }
}