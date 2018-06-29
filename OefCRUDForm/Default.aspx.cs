using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace OefCRUDForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDDL();
                ShowAll();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            txtAge.CssClass = "form-control";
            txtAddress.CssClass = "form-control";
            txtCity.CssClass = "form-control";
            txtName.Text = txtAge.Text = txtAddress.Text = txtCity.Text = txtID.Text = "";
        }

        protected void FillDDL()
        {
            ddlCommands.Items.AddRange(new ListItem[] {
                    new ListItem("INSERT", "Insert"),
                    new ListItem("UPDATE", "Update"),
                    new ListItem("DELETE", "Delete"),
                    new ListItem("FIND", "Find")
                });
        }

        protected void ShowAll()
        {
            using (SqlConnection connection = new SqlConnection(GetConnection.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select * from Persons", connection);
                connection.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            switch (ddlCommands.SelectedValue)
            {
                case "Insert":
                    Insert();
                    break;
                case "Update":
                    Update();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "Find":
                    Find();
                    break;
                default:
                    break;
            }
        }

        

        protected void ddlCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlCommands.SelectedValue)
            {
                case "Insert":
                    ReqName.Enabled = true;
                    ReqAge.Enabled = true;
                    ReqAddress.Enabled = true;
                    ReqCity.Enabled = true;
                    ReqID.Enabled = false;
                    
                    txtAge.Enabled = true;
                    txtAddress.Enabled = true;
                    txtCity.Enabled = true;
                    txtID.Visible = false;
                    break;
                case "Update":
                    ReqName.Enabled = false;
                    ReqAge.Enabled = false;
                    ReqAddress.Enabled = false;
                    ReqCity.Enabled = false;
                    ReqID.Enabled = true;

                    txtAge.Enabled = true;
                    txtAddress.Enabled = true;
                    txtCity.Enabled = true;
                    txtID.Visible = true;
                    break;
                case "Delete":
                    ReqName.Enabled = true;
                    ReqAge.Enabled = false;
                    ReqAddress.Enabled = false;
                    ReqCity.Enabled = false;
                    ReqID.Enabled = false;

                    txtAge.Enabled = false;
                    txtAddress.Enabled = false;
                    txtCity.Enabled = false;
                    txtID.Visible = false;
                    break;
                case "Find":
                    ReqName.Enabled = false;
                    ReqAge.Enabled = false;
                    ReqAddress.Enabled = false;
                    ReqCity.Enabled = false;
                    ReqID.Enabled = false;

                    txtAge.Enabled = true;
                    txtAddress.Enabled = true;
                    txtCity.Enabled = true;
                    txtID.Visible = false;
                    break;
                default:
                    break;
            }
            ShowAll();
            
        }

        protected void Insert()
        {
            string sqlString = "INSERT INTO Persons (Name, Age, Address, City) VALUES (@Name, @Age, @Address, @City)";
            using (SqlConnection connection = new SqlConnection(GetConnection.GetConnectionString()))
            {
                SqlCommand cmd = GetCommandWithParameters(sqlString, connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                lblLog.Text = $"Er zijn {rowsAffected} regels toegevoegd";
            }
            ShowAll();
        }

        protected void Update()
        {
            string sqlString = GetSqlVariables();
            if (sqlString == "")
            {
                lblLog.Text = $"Er zijn geen velden aangepast.";
                ShowAll();
                return;
            }
            sqlString = sqlString.Substring(0, sqlString.Length - 2);
            sqlString = "UPDATE Persons SET " + sqlString + $" WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(GetConnection.GetConnectionString()))
            {
                SqlCommand cmd = GetCommandWithParameters(sqlString, connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                lblLog.Text = rowsAffected == 0?"Deze ID bestaat niet.":$"Er zijn {rowsAffected} rijen aangepast.";
            }
            ShowAll();
        }

        protected void Delete()
        {
            string sqlString = "DELETE FROM Persons WHERE Name = @Name";
            using (SqlConnection connection = new SqlConnection(GetConnection.GetConnectionString()))
            {
                SqlCommand cmd = GetCommandWithParameters(sqlString, connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                lblLog.Text = $"Er zijn {rowsAffected} regels gedeletet";
            }
            ShowAll();
        }

        protected void Find()
        {
            string sqlString = "SELECT * FROM Persons WHERE Name LIKE @LikeName AND Age = @Age AND Address LIKE @LikeAddress AND City LIKE @LikeCity";
            string sqlStringNoAge = "SELECT * FROM Persons WHERE Name LIKE @LikeName AND Address LIKE @LikeAddress AND City LIKE @LikeCity";
            using (SqlConnection connection = new SqlConnection(GetConnection.GetConnectionString()))
            {
                SqlCommand cmd;
                if (txtAge.Text != "")
                {
                    cmd = GetCommandWithParameters(sqlString, connection);
                }
                else
                {
                    cmd = GetCommandWithParameters(sqlStringNoAge, connection);
                }
                
                connection.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                lblLog.Text = $"Er zijn {GridView1.Rows.Count} records gevonden.";
            }
        }

        protected string GetSqlVariables()
        {
            string sqlString = "";
            if (txtName.Text != "")
            {
                sqlString += $"Name = @Name, ";
            }
            if (txtAge.Text != "")
            {
                sqlString += $"Age = @Age, ";
            }
            if (txtAddress.Text != "")
            {
                sqlString += $"Address = @Address, ";
            }
            if (txtCity.Text != "")
            {
                sqlString += $"City = @City, ";
            }
            return sqlString;
        }

        protected SqlCommand GetCommandWithParameters(string sqlString, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(sqlString, connection);
            if (sqlString.IndexOf("@Name") != -1)
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
            }
            if (sqlString.IndexOf("@Age") != -1)
            {
                cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            }
            if (sqlString.IndexOf("@Address") != -1)
            {
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            }
            if (sqlString.IndexOf("@City") != -1)
            {
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
            }
            if (sqlString.IndexOf("@ID") != -1)
            {
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            }
            if (sqlString.IndexOf("@LikeName") != -1)
            {
                cmd.Parameters.AddWithValue("@LikeName", $"%{txtName.Text}%");
            }
            if (sqlString.IndexOf("@LikeAddress") != -1)
            {
                cmd.Parameters.AddWithValue("@LikeAddress", $"%{txtAddress.Text}%");
            }
            if (sqlString.IndexOf("@LikeCity") != -1)
            {
                cmd.Parameters.AddWithValue("@LikeCity", $"%{txtCity.Text}%");
            }
            return cmd;
        }
    }
}