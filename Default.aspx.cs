using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class _Default : Page
    {
        bool IsPageRefresh = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // initial page load - set up GridView datasource
            {
                // checks if the page postback is due to genuine submit by user or by pressing "refresh"
                ViewState["ViewStateId"] = Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();            

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("chkTaskComplete"), new DataColumn("TaskDescription") });
                Session["CurrentTable"] = dt;
                gvTODOList.DataSource = dt;
                gvTODOList.DataBind();
            }
            else
            {
                if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())
                    IsPageRefresh = true;

                Session["SessionId"] = Guid.NewGuid().ToString();
                ViewState["ViewStateId"] = Session["SessionId"].ToString();      
            }
             txtNewTask.Focus();
        }
       
        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            if (!IsPageRefresh) // browser refresh...
            {              
                Regex pattern = new Regex("(?i)^[a-z]+(?:[ -]?[a-z]+)*$");

                // validate user input
                if (pattern.IsMatch(txtNewTask.Text.Trim()) == false)
                    return;

                DataTable dt = (DataTable)Session["CurrentTable"];               

                dt.Rows.Add(false, txtNewTask.Text.Trim());             
                gvTODOList.DataSource = dt;
                gvTODOList.DataBind();

                txtNewTask.Text = string.Empty;
                Session["CurrentTable"] = dt;
            }                                            
        }
      
        protected void gvTODOList_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
            DataTable dt = (DataTable)Session["CurrentTable"];
            dt.Rows.RemoveAt(e.RowIndex);                     
            gvTODOList.DataSource = dt;
            gvTODOList.DataBind();

            Session["CurrentTable"] = dt;
        }
    }
}
