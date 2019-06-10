using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data.SqlClient;
using System.Data;
namespace Project3RWJ
{
    public partial class Registration : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        SqlCommand objStudents = new SqlCommand();
        SqlCommand SelectDept = new SqlCommand();
        SqlCommand SelectSemester = new SqlCommand();
        SqlCommand SelectCourses = new SqlCommand();
        SqlCommand SEARCHCOURSES = new SqlCommand();
        SqlCommand RegisterStudent = new SqlCommand();
        SqlCommand getRegisterID = new SqlCommand();
        SqlCommand RegisterCourses = new SqlCommand();
        SqlCommand FindStudent = new SqlCommand();
        SqlCommand CheckSameSemester = new SqlCommand();
        SqlCommand UpdateSeats = new SqlCommand();
        SqlCommand UpdateTuition = new SqlCommand();
        SqlCommand VIEWROSTER = new SqlCommand();
        SqlCommand DELETEREGISTER = new SqlCommand();
        SqlCommand DELETEREGISTER_COURSE = new SqlCommand();
        SqlCommand REMOVESEATS = new SqlCommand();
        SqlCommand REMOVETUITION = new SqlCommand();
        SqlCommand CHECKPREREQ = new SqlCommand();
        int NSeats;
        int MSeats;
        public void DBS()
        {
            gvCourses.DataSource = objDB.GetDataSetUsingCmdObj(objStudents);
            gvCourses.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectDept.CommandType = CommandType.StoredProcedure;
                SelectDept.CommandText = "SELECTDept";
                ddDept.DataSource = objDB.GetDataSetUsingCmdObj(SelectDept);
                ddRegDept.DataSource = objDB.GetDataSetUsingCmdObj(SelectDept);
                SelectSemester.CommandType = CommandType.StoredProcedure;
                SelectSemester.CommandText = "SELECTSemester";
                ddSemester.DataSource = objDB.GetDataSetUsingCmdObj(SelectSemester);
                ddRegSemester.DataSource = objDB.GetDataSetUsingCmdObj(SelectSemester);
                ddSemester.DataValueField = "Semester_Id";
                ddSemester.DataTextField = "Semester";
                ddSemester.DataBind();
                ddRegSemester.DataValueField = "Semester_Id";
                ddRegSemester.DataTextField = "Semester";
                ddRegSemester.DataBind();
                ddDept.DataValueField = "Dept_Id";
                ddDept.DataTextField = "Dept_Name";
                ddDept.DataBind();
                ddRegDept.DataValueField = "Dept_Id";
                ddRegDept.DataTextField = "Dept_Name";
                ddRegDept.DataBind();
            }
            objStudents.CommandType = CommandType.StoredProcedure;
            objStudents.CommandText = "SelectStudents";

            SEARCHCOURSES.CommandType = CommandType.StoredProcedure;
            SEARCHCOURSES.CommandText = "SEARCHCOURSES";
            DBS();

            VIEWROSTER.CommandType = CommandType.StoredProcedure;
            VIEWROSTER.CommandText = "VIEWROSTER";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "InsertStudent";
            objCommand.Parameters.AddWithValue("@name", txtName.Text);
            objCommand.Parameters.AddWithValue("@gpa", txtGPA.Text);
            objCommand.Parameters.AddWithValue("@major", txtMajor.Text);
            objCommand.Parameters.AddWithValue("@address", txtAddress.Text);
            objDB.DoUpdateUsingCmdObj(objCommand);

            SqlCommand GetNewID = new SqlCommand();
            GetNewID.CommandType = CommandType.StoredProcedure;
            GetNewID.CommandText = "Count";
            SqlParameter outputPar = new SqlParameter("@theID", 0);
            outputPar.Direction = ParameterDirection.Output;
            GetNewID.Parameters.Add(outputPar);

            objDB.GetDataSetUsingCmdObj(GetNewID);
            string id = GetNewID.Parameters["@theID"].Value.ToString();
            lblStudentID.Text = id;
            txtID.Text = id;
            //GridView


            DBS();

          
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            SelectCourses.CommandType = CommandType.StoredProcedure;
            SelectCourses.CommandText = "SELECTCOURSES";
            SelectCourses.Parameters.AddWithValue("@dept", ddDept.SelectedValue);
            SelectCourses.Parameters.AddWithValue("@semesterid", ddSemester.SelectedValue);

            gvCourses.DataSource= objDB.GetDataSetUsingCmdObj(SelectCourses);
            gvCourses.DataBind();
        }

        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            AddStudent.Visible = false;
            Register.Visible = true;

        }
        public void bindSectionsGV()
        {
            SEARCHCOURSES.Parameters.Clear();
            
            SEARCHCOURSES.Parameters.AddWithValue("@dept", ddRegDept.SelectedValue);
            SEARCHCOURSES.Parameters.AddWithValue("@semester", ddRegSemester.SelectedValue);
            gvCourseRegister.DataSource = objDB.GetDataSetUsingCmdObj(SEARCHCOURSES);
            gvCourseRegister.DataBind();
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            bindSectionsGV();
            SqlCommand GetStudentName = new SqlCommand();
            GetStudentName.CommandType = CommandType.StoredProcedure;
            GetStudentName.CommandText = "FindName";
            GetStudentName.Parameters.AddWithValue("@id", (txtID.Text));
            SqlParameter outputPar = new SqlParameter("@name",SqlDbType.VarChar,100);
            outputPar.Direction = ParameterDirection.Output;
            GetStudentName.Parameters.Add(outputPar);

            objDB.GetDataSetUsingCmdObj(GetStudentName);
            string name = GetStudentName.Parameters["@name"].Value.ToString();
            lblStudentN.Text = name;


            lblStudentDept.Text = ddRegDept.SelectedItem.Text;
        }
        protected void gvCourseRegister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Checking the RowType of the Row  
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    NSeats = Int32.Parse(e.Row.Cells[4].Text);
                    MSeats = Int32.Parse(e.Row.Cells[5].Text);
                }
                catch
                {

                }

                if (NSeats < MSeats)
                {
                    Label mylabel = ((Label)e.Row.Cells[10].FindControl("lblOpen"));
                    mylabel.Text = "OPEN";
                }
                else
                {
                    Label mylabel = ((Label)e.Row.Cells[10].FindControl("lblOpen"));
                    mylabel.Text = "CLOSED";
                }
            }
        }

        protected void btnRegisterStudent_Click(object sender, EventArgs e)
        {

            RegisterStudent.CommandType = CommandType.StoredProcedure;
            RegisterStudent.CommandText = "RegisterStudent";
            RegisterStudent.Parameters.AddWithValue("@studentId", txtID.Text);
            RegisterStudent.Parameters.AddWithValue("@Time", DateTime.Now);
            RegisterStudent.Parameters.AddWithValue("@Date", DateTime.Today);
            RegisterStudent.Parameters.AddWithValue("@semester", ddRegSemester.SelectedValue);

            RegisterCourses.CommandType = CommandType.StoredProcedure;
            RegisterCourses.CommandText = "Course_Register";

            SqlParameter outputPar = new SqlParameter("@regID", SqlDbType.VarChar, 50);
            outputPar.Direction = ParameterDirection.Output;
            getRegisterID.Parameters.Add(outputPar);

            getRegisterID.CommandType = CommandType.StoredProcedure;
            getRegisterID.CommandText = "getRegisterID";

            FindStudent.CommandType = CommandType.StoredProcedure;
            FindStudent.CommandText = "FindStudent";
            FindStudent.Parameters.AddWithValue("@id", txtID.Text);

            SqlParameter outputPar2 = new SqlParameter("@find", SqlDbType.Int, 50);
            outputPar2.Direction = ParameterDirection.Output;
            FindStudent.Parameters.Add(outputPar2);


            UpdateSeats.CommandType = CommandType.StoredProcedure;
            UpdateSeats.CommandText = "UPDATENUMSTUDENTS";

            for (int row = 0; row < gvCourseRegister.Rows.Count; row++)
            {
                RegisterCourses.Parameters.Clear();
                CheckSameSemester.Parameters.Clear();
                UpdateSeats.Parameters.Clear();
                UpdateTuition.Parameters.Clear();
                CHECKPREREQ.Parameters.Clear();
                CheckBox Cbox;
                Cbox = (CheckBox)gvCourseRegister.Rows[row].FindControl("chkEnroll");
                if (Cbox.Checked)
                {
                    objDB.GetDataSetUsingCmdObj(FindStudent);
                    string found = FindStudent.Parameters["@find"].Value.ToString();
                    //Check if Student is in the database
                    if (found == "1")
                    {
                        CheckSameSemester.CommandType = CommandType.StoredProcedure;
                        CheckSameSemester.CommandText = "CheckifStudentRegisteredSameSemester";
                        SqlParameter outputPar3 = new SqlParameter("@found", SqlDbType.Int, 50);
                        outputPar3.Direction = ParameterDirection.Output;
                        CheckSameSemester.Parameters.Add(outputPar3);
                        CheckSameSemester.Parameters.AddWithValue("@studentID", txtID.Text);
                        CheckSameSemester.Parameters.AddWithValue("@sem", ddRegSemester.Text);
                        CheckSameSemester.Parameters.AddWithValue("@courseid", gvCourseRegister.Rows[row].Cells[1].Text);
                        objDB.GetDataSetUsingCmdObj(CheckSameSemester);
                        string ssrs = CheckSameSemester.Parameters["@found"].Value.ToString();
                        //check if the user has registered in the same month 
                        //In Student ID ,semester, courseID, out returns 1 if the user had registerd for this course in the same semester
                        if (ssrs != "1")
                        {
                            //check if the course if open seats are available 
                            Label l = (Label)gvCourseRegister.Rows[row].FindControl("lblOpen");
                            if (l.Text == "OPEN")
                            {
                                CHECKPREREQ.CommandType = CommandType.StoredProcedure;
                                CHECKPREREQ.CommandText = "CHECKPREREQ";
                                //SqlParameter outputPar4 = new SqlParameter("@output", SqlDbType.Int, 50);
                                //outputPar4.Direction = ParameterDirection.Output;
                                //CHECKPREREQ.Parameters.Add(outputPar4);
                                CHECKPREREQ.Parameters.AddWithValue("@studentID", txtID.Text);
                                CHECKPREREQ.Parameters.AddWithValue("@CourseId", gvCourseRegister.Rows[row].Cells[1].Text);
                                DataSet ds = new DataSet();
                                DataTable dt = new DataTable();
                                 ds =  objDB.GetDataSetUsingCmdObj(CHECKPREREQ);
                                dt = ds.Tables[0];
                                string preReqNotTaken = "";
                                foreach (DataRow dr in dt.Rows)
                                {
                                    preReqNotTaken += dr["RequiredCourse_ID"].ToString() + ", ";

                                }
                                
                                if (preReqNotTaken == "" || preReqNotTaken == null)
                                {
                                    //inserts register field

                                    objDB.DoUpdateUsingCmdObj(RegisterStudent);

                                    //update tuition
                                    UpdateTuition.CommandType = CommandType.StoredProcedure;
                                    UpdateTuition.CommandText = "UpdateTuition";
                                    UpdateTuition.Parameters.AddWithValue("@coursehours", Int32.Parse(gvCourseRegister.Rows[row].Cells[6].Text));
                                    UpdateTuition.Parameters.AddWithValue("@studentID", txtID.Text);
                                    objDB.DoUpdateUsingCmdObj(UpdateTuition);
                                    //returns registerID of last student Registerd
                                    objDB.GetDataSetUsingCmdObj(getRegisterID);

                                    RegisterCourses.Parameters.AddWithValue("@crn", gvCourseRegister.Rows[row].Cells[0].Text);
                                    RegisterCourses.Parameters.AddWithValue("@regID", getRegisterID.Parameters["@regID"].Value.ToString());

                                    //Maps the register to section in register course
                                    objDB.DoUpdateUsingCmdObj(RegisterCourses);

                                    UpdateSeats.Parameters.AddWithValue("@crn", gvCourseRegister.Rows[row].Cells[0].Text);
                                    objDB.DoUpdateUsingCmdObj(UpdateSeats);

                                }
                                else
                                {
                                    Response.Write(preReqNotTaken + " is/are Prerequisite/s for Course ID " + gvCourseRegister.Rows[row].Cells[1].Text);
                                }


                            }
                            
                        }
                        
                    }
                    
                }
            }
            bindSectionsGV();
            bindRoster();
        }

        protected void btnViewCourses_Click(object sender, EventArgs e)
        {
            AddStudent.Visible = true;
            Register.Visible = false;
        }
        public void bindRoster()
        {
            VIEWROSTER.Parameters.Clear();
            VIEWROSTER.Parameters.AddWithValue("@studentID", txtID.Text);


            gvRoster.DataSource = objDB.GetDataSetUsingCmdObj(VIEWROSTER);
            gvRoster.DataBind();
        }
        protected void btnRoster_Click(object sender, EventArgs e)
        {
            bindRoster();




        }

        protected void btnDROP_Click(object sender, EventArgs e)
        {
            DELETEREGISTER.CommandType = CommandType.StoredProcedure;
            DELETEREGISTER.CommandText = "DELETEREGISTER";

            DELETEREGISTER_COURSE.CommandType = CommandType.StoredProcedure;
            DELETEREGISTER_COURSE.CommandText = "DELETEREGISTER_COURSE";

            REMOVESEATS.CommandType = CommandType.StoredProcedure;
            REMOVESEATS.CommandText = "REMOVESEATS";

            REMOVETUITION.CommandType = CommandType.StoredProcedure;
            REMOVETUITION.CommandText = "REMOVETUITION";
            for (int row = 0; row < gvRoster.Rows.Count; row++)
            {
                REMOVETUITION.Parameters.Clear();
                REMOVESEATS.Parameters.Clear();
                DELETEREGISTER_COURSE.Parameters.Clear();
                DELETEREGISTER.Parameters.Clear();
                CheckBox Cbox;
                Cbox = (CheckBox)gvRoster.Rows[row].FindControl("chkDrop");
                if (Cbox.Checked)
                {
                    
                    DELETEREGISTER.Parameters.AddWithValue("@reg_ID", gvRoster.Rows[row].Cells[4].Text);
                    objDB.DoUpdateUsingCmdObj(DELETEREGISTER);
                    objDB.CloseConnection();

                    DELETEREGISTER_COURSE.Parameters.AddWithValue("@register_CourseID", gvRoster.Rows[row].Cells[3].Text);
                    objDB.DoUpdateUsingCmdObj(DELETEREGISTER_COURSE);

                    objDB.CloseConnection();

                    REMOVESEATS.Parameters.AddWithValue("@crn", Int32.Parse(gvRoster.Rows[row].Cells[5].Text));
                    objDB.DoUpdateUsingCmdObj(REMOVESEATS);
                    objDB.CloseConnection();

                    REMOVETUITION.Parameters.AddWithValue("@coursehours", Int32.Parse(gvRoster.Rows[row].Cells[7].Text));
                    REMOVETUITION.Parameters.AddWithValue("@studentid",  Int32.Parse(txtID.Text));
                    objDB.DoUpdateUsingCmdObj(REMOVETUITION);

                    objDB.CloseConnection();
                }
            }
            bindRoster();
            bindSectionsGV();
        }
    }
}