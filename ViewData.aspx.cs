//Adriana Serrano

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using System.Drawing;

namespace Interface
{
    public partial class ViewData : System.Web.UI.Page
    {




        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();




        protected void Page_Load(object sender, EventArgs e)
        {

            FormatViewMode();
            //ViewMode();
            gvFormatTypes_DataBound();
            AttributeViewMode();


            if (!IsPostBack)
            {
                LoadAttributeDropDownList();
                LoadDataTypeDropDownList();
                LoadFormatTypeDropDownList();
            }

        }


        protected void LoadFormatTypeDropDownList()
        {

            ddFormatType.Items.Add(new ListItem("--Select Format Type --", ""));
            ddFormatType.AppendDataBoundItems = true;
            String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
            String strQuery = "select distinct FormatType from FormatType where InactiveDate Is Null ";
            SqlConnection con = new SqlConnection(strConnString); ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddFormatType.DataSource = cmd.ExecuteReader();
                ddFormatType.DataTextField = "FormatType";
                ddFormatType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        protected void LoadAttributeDropDownList()
        {



            ddAttributeName.Items.Add(new ListItem("--Select Attribute --", ""));
            ddAttributeName.AppendDataBoundItems = true;
            String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
            String strQuery = "SELECT DISTINCT [AttributeName] FROM [FormatAttribute]";
            SqlConnection con = new SqlConnection(strConnString); ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddAttributeName.DataSource = cmd.ExecuteReader();
                ddAttributeName.DataTextField = "AttributeName";
                ddAttributeName.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }


        }


        protected void LoadDataTypeDropDownList()
        {
            // SqlCommand newcmd = new SqlCommand();
            ddDataType.Items.Add(new ListItem("--Select Data Type --", ""));
            ddDataType.AppendDataBoundItems = true;
            String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
            String strQuery = "SELECT COUNT(ID), AttributeDataType FROM FormatAttribute GROUP BY AttributeDataType";
            SqlConnection con = new SqlConnection(strConnString); ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddDataType.DataSource = cmd.ExecuteReader();
                ddDataType.DataTextField = "AttributeDataType";
                ddDataType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }
        protected void gvFormatTypes_DataBound()
        {

            con.ConnectionString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from FormatType Where InactiveDate Is Null", con);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            gvFormatTypes.DataSource = dtbl;
            gvFormatTypes.DataBind();

        }



        protected void btnAddAttribute_Click(object sender, EventArgs e)
        {

            ClearLables();



            AddAttrbuteMode();
            AttributeNewMode();

           
        }


        protected void AddAttrbuteMode()
        {

            //clear Attribute ID, in case user had selected a row in the gridview
            txtAttributeID.Text = "";

            GridView2.SelectedIndex = -1;
            gvFormatTypes.Enabled = false;
            GridView2.Enabled = false;
            btnEditAttribute.Enabled = false;
            ddAttributeName.Enabled = true;
            txtNewAttributeName.Enabled = true;
            btnAddAttributetoDropDown.Enabled = true;
            btnCancelAttribute.Enabled = true;
            btnSaveAttribute.Enabled = true;
            ddAttributeName.SelectedIndex = 0;
            ddDataType.SelectedIndex = 0;
            txtAttributeDescription.Text = "";
            cbAllowMultiSelect.Checked = false;
            cbUserEdit.Checked = false;
        }




        protected void btnNewFormatType_Click(object sender, EventArgs e)
        {
            gvFormatTypes.SelectedIndex = -1;
            FormatNewMode();

           
        }



        protected void ViewMode()
        {




            GridView2.EmptyDataText = "No Records to Display!";
            ddFormatType.Enabled = false;
            GridView2.DataBind();
            



           



            

          







           


           


            txtAttributeLabel.Enabled = false;
            txtAttributeValue.Enabled = false;
            rbBitValue.Enabled = false;


            btnNewValue.Enabled = false;
            btnEditValue.Enabled = false;
            btnCancelValue.Enabled = false;
            btnSaveValue.Enabled = false;
            cbCopyAttributeValues.Enabled = false;
            cbIsDefault.Enabled = false;
            btnDeleteValue.Enabled = false;




        }
        protected void AddFormatTypeMode()
        {
            ddFormatType.Enabled = true;
            txtFormatType.Enabled = true;
            txtFormatDescription.Enabled = true;
            txtFormatSpecification.Enabled = true;

            btnSaveFormatType.Enabled = true;
            btnCancelFormatType.Enabled = true;
            btnNewFormatType.Enabled = false;
            cbShowInactive.Visible = true;
            cbInactive.Visible = true;
            cbInactive.Visible = true;

        }


        protected void ClearLables()
        {
            lblMessage.Text = "";
            lblAttributeMessage.Text = "";
            lblValueMessage.Text = "";
        }



        [Obsolete]
        protected void btnSaveFormatType_Click(object sender, EventArgs e)
        {


            if (txtFormatTypeID.Text != "")
            {


                int selectedPos = ddFormatType.SelectedIndex;

                ddFormatType.Items.RemoveAt(selectedPos);

                ddFormatType.Items.Insert(selectedPos, txtFormatType.Text);
                


                



                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = " UPDATE FormatType set FormatType = '" + txtFormatType.Text + "',  Description = '" + txtFormatDescription.Text + "' , FormatSpecification = '" + txtFormatSpecification.Text + "' , DateCreated = '" + txtDateCreated.Text + "' , InactiveDate = @InactiveDate " + " WHERE Id = '" + txtFormatTypeID.Text + "'";
                if (cbInactive.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@InactiveDate", DateTime.UtcNow.ToString("MM/dd/yyyy"));
                }
                else
                {

                    txtInactiveDate.Text = "";
                    cmd.Parameters.AddWithValue("@InactiveDate", DBNull.Value);

                }



                cmd.ExecuteNonQuery();
                con.Close();

                gvFormatTypes_DataBound();



                lblMessage.Visible = true;
                lblMessage.Text = "Updated successfully!";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblMessage.ClientID + "').style.display='none'\",3000)</script>");


                cbInactive.Checked = false;
                gvFormatTypes.Enabled = true;
                gvFormatTypes.SelectedIndex = -1;


                FormatViewMode();
                ClearFormatTextBoxes();
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.Text;

                cmd = new SqlCommand("INSERT INTO FormatType (FormatType,Description,FormatSpecification,DateCreated,InactiveDate) VALUES (@FormatType,@Description,@FormatSpecification,@DateCreated,@InactiveDate)", con);
                cmd.Parameters.Add("@FormatType", ddFormatType.Text);
                cmd.Parameters.Add("@Description", txtFormatDescription.Text);
                cmd.Parameters.Add("@FormatSpecification", txtFormatSpecification.Text);
                cmd.Parameters.Add("@DateCreated", txtDateCreated.Text.Replace("&nbsp;", " "));
                cmd.Parameters.Add("@InactiveDate", txtDateCreated.Text.Replace("&nbsp;", " "));

                cmd.Parameters["@InactiveDate"].Value = DBNull.Value;

                cmd.ExecuteNonQuery();
                con.Close();


                gvFormatTypes_DataBound();


                lblMessage.Visible = true;
                lblMessage.Text = "Saved!";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblMessage.ClientID + "').style.display='none'\",3000)</script>");







                FormatViewMode();
                ClearFormatTextBoxes();
            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ClearLables();


            if (txtFormatTypeID.Text == "")
            {
                FormatViewMode();
            }
            else
            {
                FormatViewMode();
            }
            
        }


        [Obsolete]
        protected void btnSaveAttribute_Click(object sender, EventArgs e)
        {

            //if user has selected a row from the Attribute Grid then it will do the update statement, if they haven't selected anything, this means it is NEW and it will insert the information to the database. 
            if (txtAttributeID.Text != "")
            {

                int selectedPos = ddAttributeName.SelectedIndex;

                ddAttributeName.Items.RemoveAt(selectedPos);

                ddAttributeName.Items.Insert(selectedPos, txtNewAttributeName.Text);
               
                btnSaveAttribute.Enabled = true;
                ddAttributeName.Enabled = true;
                ddDataType.Enabled = true;
                txtAttributeDescription.Enabled = true;
                cbAllowMultiSelect.Enabled = true;
                cbUserEdit.Enabled = true;

                ddAttributeName.SelectedIndex = selectedPos;


                //update existing attribute
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " UPDATE FormatAttribute set AttributeName = '" + txtNewAttributeName.Text + "',  AttributeDataType = '" + ddDataType.Text + "' , AllowMultiSelect = '" + cbAllowMultiSelect.Checked + "' , AllowUserEdit = '" + cbUserEdit.Checked + "' , Description = '" + txtAttributeDescription.Text + "' WHERE ID = '" + txtAttributeID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                GridView2.DataBind();


                lblAttributeMessage.Visible = true;
                lblAttributeMessage.Text = "Updated successfully!";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");


                gvFormatTypes.Enabled = true;
                txtNewAttributeName.Text = "";
                btnAddAttributetoDropDown.Enabled = false;




                GridView2.Enabled = true;
                gvFormatTypes.Enabled = true;


                ddAttributeName.SelectedIndex = 0;
                ddDataType.SelectedIndex = 0;
                txtAttributeDescription.Text = "";
                cbAllowMultiSelect.Checked = false;
                cbUserEdit.Checked = false;
                btnAddAttribute.Enabled = true;
                btnEditAttribute.Enabled = false;
                btnSaveAttribute.Enabled = false;
                btnCancelAttribute.Enabled = false;
                GridView2.SelectedIndex = -1;


                ddAttributeName.Enabled = false;
                ddDataType.Enabled = false;
                txtAttributeDescription.Enabled = false;
                cbAllowMultiSelect.Enabled = false;

                cbUserEdit.Enabled = false;

            }
            else
            {
                //create new attribute
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("INSERT INTO FormatAttribute (AttributeName,AttributeDataType,AllowMultiSelect,AllowUserEdit,Description,FormatTypeID) VALUES (@AttributeName,@AttributeDataType,@AllowMultiSelect,@AllowUserEdit,@Description,@FormatTypeID)", con);
                cmd.Parameters.Add("@AttributeName", ddAttributeName.Text.ToString());
                cmd.Parameters.Add("@AttributeDataType", ddDataType.SelectedItem.ToString());
                cmd.Parameters.Add("@AllowMultiSelect", cbAllowMultiSelect.Checked.ToString());
                cmd.Parameters.Add("@AllowUserEdit", cbUserEdit.Checked.ToString());
                cmd.Parameters.Add("@Description", txtAttributeDescription.Text);
                cmd.Parameters.Add("@FormatTypeID", txtFormatTypeID.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                lblAttributeMessage.Visible = true;
                lblAttributeMessage.Text = "Attribute saved successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");

                GridView2.DataBind();
                txtNewAttributeName.Text = "";

                gvFormatTypes.Enabled = true;
                GridView2.SelectedIndex = -1;
                GridView2.Enabled = true;
                gvFormatTypes.Enabled = true;


                ddAttributeName.SelectedIndex = 0;
                ddDataType.SelectedIndex = 0;
                txtAttributeDescription.Text = "";
                cbAllowMultiSelect.Checked = false;
                btnAddAttribute.Enabled = true;
                cbUserEdit.Checked = false;


            }

        }


        protected void btnCancelAttribute_Click(object sender, EventArgs e)
        {
            ClearLables();
            ViewMode();

            if (txtAttributeID.Text == "")
            {
                btnAddAttribute.Enabled = true;
                btnEditAttribute.Enabled = false;
                btnDeleteAttribute.Enabled = true;
                txtNewAttributeName.Text = "";
                GridView2.Enabled = true;
                gvFormatTypes.Enabled = true;

                ddAttributeName.SelectedIndex = 0;
                ddDataType.SelectedIndex = 0;
                txtAttributeDescription.Text = "";
                cbAllowMultiSelect.Checked = false;
                cbUserEdit.Checked = false;
            }
            else
            {
                btnAddAttribute.Enabled = true;
                btnEditAttribute.Enabled = true;
                btnDeleteAttribute.Enabled = true;
                txtNewAttributeName.Text = "";
                GridView2.Enabled = true;
                gvFormatTypes.Enabled = true;



            }
        }


        protected void FormatViewMode()
        {
            //text boxes disabled, user cannot enter info 
            ddFormatType.Enabled = false;
            txtFormatDescription.Enabled = false;
            txtFormatSpecification.Enabled = false;
            txtFormatType.Enabled = false; 

            //user can add a new format type file starting off 
            btnNewFormatType.Enabled = true;

            //rest of the buttons are disabled until the select something from the gridview
            btnEditFormatType.Enabled = false;
            btnCancelFormatType.Enabled = false;
            btnSaveFormatType.Enabled = false;
            btnAddFormatTypetoDropDownList.Enabled = false;


            //user can see inactive format types if they would like to compare, they can see it in view mode 
            cbShowInactive.Visible = true;

            // this is used in order to deactivate a format type, should be only done in edit mode, they cannot see it in view mode
            cbInactive.Visible = false;

            //gridview should be enabled 
            gvFormatTypes.Enabled = true;

            //no selection 
            
        }

        protected void AttributeNewMode()
        {


            cbCopyAttributeValues.Enabled = false;
            cbAttributeValues.Visible = true;

            txtAttributeID.Text = "";

            GridView2.SelectedIndex = -1;
            gvFormatTypes.Enabled = false;
            GridView2.Enabled = false;
            btnEditAttribute.Enabled = false;
            ddAttributeName.Enabled = true;
            txtNewAttributeName.Enabled = true;
            btnAddAttributetoDropDown.Enabled = true;
            btnCancelAttribute.Enabled = true;
            btnSaveAttribute.Enabled = true;
            


        }


        protected void FormatEditView()
        {


            GridViewRow gr = gvFormatTypes.SelectedRow;
            txtDateCreated.Text = gr.Cells[5].Text.Replace("&nbsp;", " ");
           
            //fill in the formattype selected in the textbox

            //txtFormatType.Text = gvFormatTypes.SelectedRow.Cells[2].Text;


            //text boxes disabled, user cannot enter info 
            ddFormatType.Enabled = false;
            txtFormatDescription.Enabled = true;
            txtFormatSpecification.Enabled = true;
            txtFormatType.Enabled = true;

            //user can add a new format type file starting off 
            btnNewFormatType.Enabled = true;

            //rest of the buttons are disabled until the select something from the gridview
            btnEditFormatType.Enabled = false;
            btnCancelFormatType.Enabled = true;
            btnSaveFormatType.Enabled = true;
            btnAddFormatTypetoDropDownList.Enabled = false;


            //user can see inactive format types if they would like to compare, they can see it in view mode 
            cbShowInactive.Visible = false;

            // this is used in order to deactivate a format type, should be only done in edit mode, they cannot see it in view mode
            cbInactive.Visible = true;

            //gridview should be enabled 
            gvFormatTypes.Enabled = false;
                                           
           




            if (cbShowInactive.Checked == true)
            {

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from FormatType", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvFormatTypes.DataSource = dtbl;
                gvFormatTypes.DataBind();
            }
            else
            {
                gvFormatTypes_DataBound();

            }


           



            if (gvFormatTypes.SelectedRow.Cells[6].Text != "&nbsp;")
            {
                cbInactive.Checked = true;
            }
            else
            {
                cbInactive.Checked = false;
            }

            
        }

        




        protected void FormatNewMode()
        {

            ClearFormatTextBoxes();

            //text boxes disabled, user cannot enter info 
            ddFormatType.Enabled = true;
            txtFormatDescription.Enabled = true;
            txtFormatSpecification.Enabled = true;
            txtFormatType.Enabled = true;

            //user can add a new format type file starting off 
            btnNewFormatType.Enabled = false;

            //rest of the buttons are disabled until the select something from the gridview
            btnEditFormatType.Enabled = false;
            btnCancelFormatType.Enabled = true;
            btnSaveFormatType.Enabled = true;
            btnAddFormatTypetoDropDownList.Enabled = true;


            //in new mode they should be able to see inactive format types 
            cbShowInactive.Visible = false;

            // this is used in order to deactivate a format type, should be only done in edit mode, they cannot see it in view mode
            cbInactive.Visible = false;

           

            //get the create date in order to save in the database 
            txtDateCreated.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");

            //clear anything that might be transfered into this box 
            txtInactiveDate.Text = "";

            //gridview should be disabled 
            gvFormatTypes.Enabled = false; 

        }

        protected void ClearFormatTextBoxes()
        {

            //clear text boxes in order for user to enter new data for new format type 
            ddFormatType.SelectedIndex = 0;
            txtFormatType.Text = "";
            txtFormatDescription.Text = "";
            txtFormatSpecification.Text = "";
            txtFormatTypeID.Text = "";
            txtFormatType.Text = "";
        } 






        protected void btnEditFormatType_Click(object sender, EventArgs e)
        {

            ClearLables();
            FormatEditView();


        }

        protected void cbRuntimeOptimized_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbCOMapping_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddAttributeName_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnEditAttribute.Enabled = true;
            cbCopyAttributeValues.Enabled = true;
            if (!IsPostBack == false)
            {

                String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
                string strQuery = "select * from FormatAttribute where AttributeName ='" + ddAttributeName.SelectedItem + "'";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", ddAttributeName.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                SqlDataReader myreader;

                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    ddDataType.Text = myreader["AttributeDataType"].ToString();
                    txtAttributeDescription.Text = myreader["Description"].ToString();
                    cbAllowMultiSelect.Checked = Convert.ToBoolean(myreader["AllowMultiSelect"]);
                    cbUserEdit.Checked = Convert.ToBoolean(myreader["AllowUserEdit"]);
                    myreader.Close();
                }
                finally
                {

                    con.Close();
                }

                ddAttributeName.Enabled = true;
                btnCancelAttribute.Enabled = true;
                btnEditAttribute.Enabled = false;
                btnSaveAttribute.Enabled = true;
                cbCopyAttributeValues.Enabled = true;

            }




        }



        protected void getAttributeinfo()
        {


            if (!IsPostBack == false)
            {

                String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
                string strQuery = "select * from FormatAttribute where AttributeName ='" + ddAttributeName.SelectedItem + "'";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", ddAttributeName.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                SqlDataReader myreader;

                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    ddDataType.Text = myreader["AttributeDataType"].ToString();
                    txtAttributeDescription.Text = myreader["Description"].ToString();
                    cbAllowMultiSelect.Checked = Convert.ToBoolean(myreader["AllowMultiSelect"]);
                    cbUserEdit.Checked = Convert.ToBoolean(myreader["AllowUserEdit"]);
                    myreader.Close();
                }
                finally
                {

                    con.Close();
                }

                ddAttributeName.Enabled = true;
                btnCancelAttribute.Enabled = true;
                btnEditAttribute.Enabled = false;
                btnSaveAttribute.Enabled = true;
                cbCopyAttributeValues.Enabled = true;

            }
        }






        protected void cbInactive_CheckedChanged(object sender, EventArgs e)
        {

            txtInactiveDate.Text = DateTime.UtcNow.ToString();
        }

        protected void cbShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            ClearLables();
            if (cbShowInactive.Checked == true)
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from FormatType", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvFormatTypes.DataSource = dtbl;
                gvFormatTypes.DataBind();

                gvFormatTypes.SelectedIndex = -1;
                btnNewFormatType.Enabled = true;

            }
            else
            {

                btnNewFormatType.Enabled = true;
                gvFormatTypes.SelectedIndex = -1;

                gvFormatTypes_DataBound();

            }
        }


        protected void AttributeViewMode()
        {

            ddAttributeName.Enabled = false;
            ddDataType.Enabled = false;
            txtAttributeDescription.Enabled = false;
            cbAllowMultiSelect.Enabled = false;
            cbUserEdit.Enabled = false;



            btnCancelAttribute.Enabled = false;
            btnEditAttribute.Enabled = false;

            btnDeleteAttribute.Enabled = false;
            btnSaveAttribute.Enabled = false;

            txtNewAttributeName.Enabled = false;
            btnAddAttributetoDropDown.Enabled = false;

            btnNewAttributeName.Enabled = false;

            btnAddAttribute.Enabled = false;
            cbCopyAttributeValues.Enabled = false;
            cbAttributeValues.Visible = false;





        }


        protected void gvFormatTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddAttribute.Enabled = true; 

            ClearLables();

            if (cbShowInactive.Checked == true)
            {

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * from FormatType", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvFormatTypes.DataSource = dtbl;
                gvFormatTypes.DataBind();

            }
            else
            {

                gvFormatTypes_DataBound();
            }


            btnAddAttribute.Visible = true;

            GridViewRow gr = gvFormatTypes.SelectedRow;
            txtFormatTypeID.Text = gr.Cells[1].Text.Replace("&nbsp;", " ");
            ddFormatType.Text = gr.Cells[2].Text.Replace("&nbsp;", " ");

            txtFormatDescription.Text = gr.Cells[3].Text.Replace("&nbsp;", " ");
            txtFormatSpecification.Text = gr.Cells[4].Text.Replace("&nbsp;", " ");

            btnEditFormatType.Enabled = true;
            btnNewFormatType.Enabled = true;
            lblAttributes.Visible = true;
          


            txtDateCreated.Text = gr.Cells[6].Text.Replace("&nbsp;", " ");

            if (txtFormatType.Text == "")
            {
                GridView2.EmptyDataText = "";
            }
            else
            {
                GridView2.EmptyDataText = "No attributes found!";

            }

            cbInactive.Checked = false;
            lblAttributeMessage.Text = "";
            btnAddAttribute.Visible = true;


            if (txtFormatTypeID.Text == "")
            {
                btnAddAttribute.Enabled = false;
            }
            else
            {
                btnAddAttribute.Enabled = true;

            }

            txtAttributeID.Text = "";

            ddAttributeName.SelectedIndex = 0;
            ddDataType.SelectedIndex = 0;
            txtAttributeDescription.Text = "";
            cbAllowMultiSelect.Checked = false;
            cbUserEdit.Checked = false;
            GridView2.SelectedIndex = -1;
            GridView2.EmptyDataText = "No Records to Display!";
        }

        protected void gvFormatTypes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            gvFormatTypes.PageIndex = e.NewPageIndex;
            gvFormatTypes.DataBind();
        }

        protected void btnNewAttributeName_Click(object sender, EventArgs e)
        {

            AttributeNewMode();
            ddDataType.Enabled = true;

            ddDataType.Items.Clear();
            ddAttributeName.ClearSelection();


            txtAttributeDescription.Text = "";
            cbAllowMultiSelect.Checked = false;
            cbUserEdit.Checked = false;
            btnEditAttribute.Enabled = false;
            btnDeleteAttribute.Enabled = false;
            btnNewAttributeName.Enabled = false;
            txtNewAttributeName.Enabled = true;
            btnAddAttributetoDropDown.Enabled = true;





            /*

            SqlCommand cmd = new SqlCommand();
            ddDataType.Items.Add(new ListItem("--Select Data Type --", ""));
            ddDataType.AppendDataBoundItems = true;
            String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
            String strQuery = "SELECT COUNT(ID), AttributeDataType FROM FormatAttribute GROUP BY AttributeDataType";
            SqlConnection con = new SqlConnection(strConnString); ;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddDataType.DataSource = cmd.ExecuteReader();
                ddDataType.DataTextField = "AttributeDataType";
           
                ddDataType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }*/

            lblAttributeMessage.Text = "";
        }

        

        [Obsolete]
        protected void btnSaveNewAttribute_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("INSERT INTO FormatAttribute (AttributeName,AttributeDataType,AllowMultiSelect,AllowUserEdit,Description,FormatTypeID) VALUES (@AttributeName,@AttributeDataType,@AllowMultiSelect,@AllowUserEdit,@Description,@FormatTypeID)", con);
            cmd.Parameters.Add("@AttributeName", ddAttributeName.Text.ToString());
            cmd.Parameters.Add("@AttributeDataType", ddDataType.SelectedItem.ToString());
            cmd.Parameters.Add("@AllowMultiSelect", cbAllowMultiSelect.Checked.ToString());
            cmd.Parameters.Add("@AllowUserEdit", cbUserEdit.Checked.ToString());
            cmd.Parameters.Add("@Description", txtAttributeDescription.Text);
            cmd.Parameters.Add("@FormatTypeID", txtFormatTypeID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void btnAddAttributetoDropDown_Click(object sender, EventArgs e)
        {

            if (txtAttributeID.Text == "")
            {
                // ddAttributeName.Enabled = true;
                if (IsPostBack)
                {
                    if (txtNewAttributeName.Text.Trim() != "")
                    {
                        ddAttributeName.Items.Insert(1, new ListItem(txtNewAttributeName.Text));
                        ddAttributeName.SelectedIndex = 1;
                        AttributeNewMode();
                        ddDataType.Enabled = true;
                    }


                    AttributeNewMode();
                    ddDataType.Enabled = true;

                    //ddDataType.Items.Clear();
                    //ddAttributeName.ClearSelection();


                    txtAttributeDescription.Text = "";
                    cbAllowMultiSelect.Checked = false;
                    cbUserEdit.Checked = false;


                    if (!IsPostBack)
                    {
                        LoadDataTypeDropDownList();
                    }



                }
            }
            else
            {


                GridViewRow gr2 = GridView2.SelectedRow;
                txtAttributeID.Text = gr2.Cells[1].Text.Replace("&nbsp;", " ");
                btnEditAttribute.Enabled = false;

                ddAttributeName.Items.Insert(0, new ListItem(txtNewAttributeName.Text));
                ddAttributeName.SelectedIndex = 0;
                ddDataType.Text = gr2.Cells[3].Text.Replace("&nbsp;", " ");
                txtAttributeDescription.Text = gr2.Cells[6].Text.Replace("&nbsp;", " ");
                CheckBox chk = gr2.Cells[5].Controls[0] as CheckBox;

                if (chk.Checked == true)
                {
                    cbUserEdit.Checked = true;
                }
                else
                {
                    cbUserEdit.Checked = false;
                }


                CheckBox chkMultiSelect = gr2.Cells[4].Controls[0] as CheckBox;

                if (chkMultiSelect.Checked == true)
                {
                    cbAllowMultiSelect.Checked = true;
                }
                else
                {
                    cbAllowMultiSelect.Checked = false;
                }


                ddAttributeName.Enabled = true;
                txtNewAttributeName.Enabled = true;
                ddDataType.Enabled = true;
                txtAttributeDescription.Enabled = true;
                cbAllowMultiSelect.Enabled = true;
                cbUserEdit.Enabled = true;
                btnSaveAttribute.Enabled = true;
                btnCancelAttribute.Enabled = true;
                txtNewAttributeName.Enabled = true;


            }






        }



        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ClearLables();
            btnDeleteAttribute.Visible = true;



            GridViewRow gr2 = GridView2.SelectedRow;

            txtDataType.Text = gr2.Cells[3].Text.Replace("&nbsp;", " ");


            txtAttributeID.Text = gr2.Cells[1].Text.Replace("&nbsp;", " ");
            ddAttributeName.Text = gr2.Cells[2].Text.Replace("&nbsp;", " ");
            ddDataType.Text = gr2.Cells[3].Text.Replace("&nbsp;", " ");
            txtAttributeDescription.Text = gr2.Cells[6].Text.Replace("&nbsp;", " ");
            CheckBox chk = gr2.Cells[5].Controls[0] as CheckBox;

            if (chk.Checked == true)
            {
                cbUserEdit.Checked = true;
            }
            else
            {
                cbUserEdit.Checked = false;
            }


            CheckBox chkMultiSelect = gr2.Cells[4].Controls[0] as CheckBox;

            if (chkMultiSelect.Checked == true)
            {
                cbAllowMultiSelect.Checked = true;
            }
            else
            {
                cbAllowMultiSelect.Checked = false;
            }







            if (GridView2.Rows.Count < 0)
            {

                btnCancelAttribute.Enabled = false;

            }
            else
            {
                btnCancelAttribute.Enabled = false;
                btnEditAttribute.Enabled = true;
                btnNewAttributeName.Enabled = true;
                btnDeleteAttribute.Enabled = true;
                btnAddAttribute.Enabled = true;
            }

            GridView3.SelectedIndex = -1;
            txtAttributeLabel.Text = "";
            txtAttributeValue.Text = "";
            rbBitValue.SelectedIndex = -1;

            btnNewValue.Enabled = true;

        }









        protected void btnDeleteAttribute_Click(object sender, EventArgs e)
        {

            ClearLables();

            try
            {

                if (GridView2.SelectedValue != null)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " Delete From FormatAttribute Where ID = '" + txtAttributeID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblAttributeMessage.Visible = true;
                    lblAttributeMessage.Text = "Attribute Deleted!";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");





                    GridView2.DataBind();
                    gvFormatTypes.Focus();

                    ddAttributeName.SelectedIndex = 0;
                    ddDataType.SelectedIndex = 0;
                    txtAttributeDescription.Text = "";
                    cbAllowMultiSelect.Checked = false;
                    cbUserEdit.Checked = false;
                    btnAddAttribute.Enabled = true;
                    GridView2.SelectedIndex = -1;




                }
                else
                {



                    lblAttributeMessage.Visible = true;
                    lblAttributeMessage.Text = "please select attribute that you would like to delete";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");

                }
            }
            catch
            {

                lblAttributeMessage.Visible = true;
                lblAttributeMessage.Text = "unable to delete as the record is linked to another table, delete related record first";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");




            }



        }

        protected void btnEditAttribute_Click(object sender, EventArgs e)
        {

            ClearLables();
            cbCopyAttributeValues.Enabled = true;

            if (IsPostBack == true)
            {
                btnAddAttribute.Visible = true;
                EditAttributeMode();
                btnAddAttributetoDropDown.Enabled = false;
                ddAttributeName.Enabled = false;


            }

        }

        protected void EditAttributeMode()
        {
            gvFormatTypes.Enabled = false;
            ddAttributeName.Enabled = true;
            txtNewAttributeName.Text = ddAttributeName.SelectedValue;
            ddDataType.Enabled = true;
            txtAttributeDescription.Enabled = true;
            cbAllowMultiSelect.Enabled = true;
            cbUserEdit.Enabled = true;
            txtNewAttributeName.Enabled = true;
            btnAddAttributetoDropDown.Enabled = true;
            btnSaveAttribute.Enabled = true;
            btnCancelAttribute.Enabled = true;


        }



        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteValue.Enabled = true;
            btnEditValue.Enabled = true;

            GridViewRow gr3 = GridView3.SelectedRow;

            txtFormatAttributeValueID.Text = gr3.Cells[1].Text.Replace("&nbsp;", " ");


            if (txtDataType.Text == "string")
            {


                txtAttributeLabel.Text = gr3.Cells[2].Text.Replace("&nbsp;", " ");
                txtAttributeValue.Text = gr3.Cells[3].Text.Replace("&nbsp;", " ");
                rbBitValue.SelectedIndex = -1;

                CheckBox chkMultiSelect = gr3.Cells[4].Controls[0] as CheckBox;

                if (chkMultiSelect.Checked == true)
                {
                    cbIsDefault.Checked = true;
                }
                else
                {
                    cbIsDefault.Checked = false;
                }


            }
            else if (txtDataType.Text == "int")
            {
                txtAttributeLabel.Text = gr3.Cells[2].Text.Replace("&nbsp;", " ");
                txtAttributeValue.Text = gr3.Cells[3].Text.Replace("&nbsp;", " ");
                rbBitValue.SelectedIndex = -1;


                CheckBox chkMultiSelect = gr3.Cells[4].Controls[0] as CheckBox;

                if (chkMultiSelect.Checked == true)
                {
                    cbIsDefault.Checked = true;
                }
                else
                {
                    cbIsDefault.Checked = false;
                }
            }
            else
            {


                txtAttributeLabel.Text = gr3.Cells[2].Text.Replace("&nbsp;", " ");
                txtAttributeValue.Text = "";

                //getting the value in the Value coloum in FormatAttributeValue Gridview
                string bitvalue = gr3.Cells[3].Text.Replace("&nbsp;", " ");

                if (bitvalue == "1")
                {
                    rbBitValue.SelectedIndex = 1;
                }
                else
                {
                    rbBitValue.SelectedIndex = 0;
                }

                //getting the value of IsDefault in the gridview 
                CheckBox chkMultiSelect = gr3.Cells[4].Controls[0] as CheckBox;

                if (chkMultiSelect.Checked == true)
                {
                    cbIsDefault.Checked = true;
                }
                else
                {
                    cbIsDefault.Checked = false;
                }




            }

            btnNewValue.Enabled = true;

            //****if the attribute has AllowUserEdit checked then the Edit button will be enabled, if not they can not edit ***** 

            GridViewRow gr2 = GridView2.SelectedRow;

            CheckBox chkUserEdit = gr2.Cells[5].Controls[0] as CheckBox;


        }

        protected void btnNewValue_Click(object sender, EventArgs e)
        {
            ClearLables();

            btnCancelValue.Enabled = true;
            btnSaveValue.Enabled = true;

            GridView2.Enabled = false;
            gvFormatTypes.Enabled = false;
            cbIsDefault.Enabled = true;

            if (txtDataType.Text == "string")
            {
                txtAttributeValue.Enabled = true;
                txtAttributeLabel.Enabled = true;
                rbBitValue.Enabled = false;
                txtAttributeValue.Text = "";
                txtAttributeLabel.Text = "";
                GridView3.SelectedIndex = -1;
                GridView3.Enabled = false;

            }
            else
            {
                txtAttributeValue.Enabled = false;
                rbBitValue.Enabled = true;
                rbBitValue.SelectedIndex = -1;
                txtAttributeLabel.Enabled = true;
                txtAttributeValue.Text = "";
                txtAttributeLabel.Text = "";
                GridView3.SelectedIndex = -1;


            }
        }

        protected void btnEditValue_Click(object sender, EventArgs e)
        {
            ClearLables();
            btnCancelValue.Enabled = true;
            btnSaveValue.Enabled = true;
            cbIsDefault.Enabled = true;


            ClearLables();
            if (txtDataType.Text == "string")
            {
                txtAttributeValue.Enabled = true;
                txtAttributeLabel.Enabled = true;

                rbBitValue.Enabled = false;

            }
            else
            {
                txtAttributeLabel.Enabled = true;
                txtAttributeValue.Enabled = false;
                rbBitValue.Enabled = true;


            }





        }

        [Obsolete]
        protected void btnSaveValue_Click(object sender, EventArgs e)
        {

            if (txtFormatAttributeValueID.Text == "")
            {

                if (txtDataType.Text == "string")
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd = new SqlCommand("INSERT INTO FormatAttributeValue (FormatAttributeID, AttributeLabel,AttributeValue,IsDefault) VALUES (@FormatAttributeID, @AttributeLabel,@AttributeValue,@IsDefault)", con);
                    cmd.Parameters.Add("@FormatAttributeID", txtAttributeID.Text.ToString());
                    cmd.Parameters.Add("@AttributeLabel", txtAttributeLabel.Text.ToString());
                    cmd.Parameters.Add("@AttributeValue", txtAttributeValue.Text.ToString());
                    cmd.Parameters.Add("@IsDefault", cbIsDefault.Checked.ToString());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView3.DataBind();

                    GridView2.Enabled = true;
                    GridView3.Enabled = true;
                    gvFormatTypes.Enabled = true;

                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "Attribute Value saved successfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblValueMessage.ClientID + "').style.display='none'\",3000)</script>");

                }
                else
                {

                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd = new SqlCommand("INSERT INTO FormatAttributeValue (FormatAttributeID, AttributeLabel,AttributeValue,IsDefault) VALUES (@FormatAttributeID, @AttributeLabel,@AttributeValue,@IsDefault)", con);
                    cmd.Parameters.Add("@FormatAttributeID", txtAttributeID.Text.ToString());
                    cmd.Parameters.Add("@AttributeLabel", txtAttributeLabel.Text.ToString());
                    cmd.Parameters.Add("@AttributeValue", rbBitValue.SelectedIndex.ToString());
                    cmd.Parameters.Add("@IsDefault", cbIsDefault.Checked.ToString());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView3.DataBind();

                    GridView2.Enabled = true;
                    GridView3.Enabled = true;
                    gvFormatTypes.Enabled = true;

                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "Attribute Value saved successfully";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblValueMessage.ClientID + "').style.display='none'\",3000)</script>");



                }






            }
            else
            {

                if (txtDataType.Text == "string")
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE FormatAttributeValue set AttributeLabel = '" + txtAttributeLabel.Text + "',  AttributeValue = '" + txtAttributeValue.Text + "' , IsDefault = '" + cbIsDefault.Checked + "' WHERE ID = '" + txtFormatAttributeValueID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView3.DataBind();


                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "Updated successfully!";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblValueMessage.ClientID + "').style.display='none'\",3000)</script>");
                    GridView3.Enabled = true;
                }
                else
                {


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " UPDATE FormatAttributeValue set AttributeLabel = '" + txtAttributeLabel.Text + "',  AttributeValue = '" + rbBitValue.SelectedIndex + "' , IsDefault = '" + cbIsDefault.Checked + "' WHERE ID = '" + txtFormatAttributeValueID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView3.DataBind();


                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "Updated successfully!";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblValueMessage.ClientID + "').style.display='none'\",3000)</script>");

                    GridView3.Enabled = true;

                }



            }


        }


        protected void btnCancelValue_Click(object sender, EventArgs e)
        {
            ClearLables();
            GridView3.SelectedIndex = -1;
            GridView3.Enabled = true;
            btnNewValue.Enabled = true;
            GridView2.Enabled = true;
            gvFormatTypes.Enabled = true;
            btnNewValue.Enabled = true;

            txtAttributeLabel.Text = "";
            txtAttributeValue.Text = "";
            rbBitValue.SelectedIndex = -1;
            cbCopyAttributeValues.Checked = false;
            cbIsDefault.Checked = false;
        }

        protected void btnDeleteValue_Click(object sender, EventArgs e)
        {

            try
            {

                if (GridView3.SelectedValue != null)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " Delete From FormatAttributeValue Where ID = '" + txtFormatAttributeValueID.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();


                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "Attribute Deleted!";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblValueMessage.ClientID + "').style.display='none'\",3000)</script>");





                    GridView3.DataBind();




                }
                else
                {



                    lblValueMessage.Visible = true;
                    lblValueMessage.Text = "please select attribute that you would like to delete";
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");

                }
            }
            catch
            {

                lblValueMessage.Visible = true;
                lblValueMessage.Text = "unable to delete as the record is linked to another table, delete related record first";
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + lblAttributeMessage.ClientID + "').style.display='none'\",3000)</script>");




            }

        }

        protected void cbCopyAttributeValues_CheckedChanged(object sender, EventArgs e)
        {

            if (cbCopyAttributeValues.Checked == true)
            {

                String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";

                SqlConnection con = new SqlConnection(strConnString);
                string strQuery = "select  distinct AttributeValue from FormatAttributeValue, FormatAttribute Where FormatAttributeID = dbo.FormatAttribute.ID AND AttributeName ='" + ddAttributeName.Text + "'";
                SqlCommand cmd = new SqlCommand(strQuery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cbAttributeValues.DataTextField = "AttributeValue";
                cbAttributeValues.DataValueField = "AttributeValue";
                cbAttributeValues.DataSource = dt;
                cbAttributeValues.DataBind();
                con.Close();
                AttributeNewMode();
               
            }
            else
            {
                cbAttributeValues.DataBind();
               AttributeNewMode();
              
            }

            
        }

        protected void btnAddFormatTypetoDropDownList_Click(object sender, EventArgs e)
        {


            if (txtFormatTypeID.Text == "")
            {
                // ddAttributeName.Enabled = true;
                if (IsPostBack)
                {
                    if (txtFormatType.Text.Trim() != "")
                    {
                        ddFormatType.Items.Insert(1, new ListItem(txtFormatType.Text));
                        ddFormatType.SelectedIndex = 1;
                        txtFormatDescription.Enabled = true;
                        txtFormatSpecification.Enabled = true;
                        btnCancelFormatType.Enabled = true; 
                        btnSaveFormatType.Enabled = true;

                    }

                }

                txtFormatType.Text = "";



            }
        }

        protected void ddFormatType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!IsPostBack == false)
           {

                String strConnString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = ContentDelivery; Integrated Security = True";
                string strQuery = "select * from FormatType where FormatType ='" + ddFormatType.SelectedItem + "'";
                SqlConnection con = new SqlConnection(strConnString);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", ddFormatType.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                SqlDataReader myreader;

                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    myreader.Read();


                    txtFormatDescription.Text = myreader["Description"].ToString();
                    txtFormatSpecification.Text = myreader["FormatSpecification"].ToString();

                    myreader.Close();
                }
                finally
                {

                    con.Close();
                }

                ddFormatType.Enabled = false;
                txtFormatDescription.Enabled = false;
                txtFormatSpecification.Enabled = false;
                btnCancelFormatType.Enabled = true;
                btnSaveFormatType.Enabled = true; 

           }
        }

        protected void ddFormatType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}



   

