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
    public partial class Courses : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        SqlCommand getCourses = new SqlCommand();
        SqlCommand ADDCOURSE = new SqlCommand();
        SqlCommand DELETECOURSE = new SqlCommand();
        SqlCommand MODIFYCOURSE = new SqlCommand();
        SqlCommand SelectDept = new SqlCommand();
        SqlCommand SelectSemester = new SqlCommand();
        SqlCommand SelectProfessor = new SqlCommand();
        SqlCommand fillddCourses = new SqlCommand();
        SqlCommand ADDSection = new SqlCommand();
        SqlCommand DELETESection = new SqlCommand();
        SqlCommand MODIFYSection = new SqlCommand();
        SqlCommand DISPLAYSECTIONS = new SqlCommand();
        public void DataBindSource()
        {
            gvCourses.DataSource = db.GetDataSetUsingCmdObj(getCourses);
            gvCourses.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            getCourses.CommandType = CommandType.StoredProcedure;
            getCourses.CommandText = "GetAllCourses";
            DataBindSource();

            if (!IsPostBack)
            {
                SelectDept.CommandType = CommandType.StoredProcedure;
                SelectDept.CommandText = "SELECTDept";
                ddDeptID.DataSource = db.GetDataSetUsingCmdObj(SelectDept);
              
                SelectSemester.CommandType = CommandType.StoredProcedure;
                SelectSemester.CommandText = "SELECTSemester";
                ddSemester.DataSource = db.GetDataSetUsingCmdObj(SelectSemester);
               
                ddSemester.DataValueField = "Semester_Id";
                ddSemester.DataTextField = "Semester";
                ddSemester.DataBind();
                ddDeptID.DataValueField = "Dept_Id";
                ddDeptID.DataTextField = "Dept_Name";
                ddDeptID.DataBind();

                SelectProfessor.CommandType = CommandType.StoredProcedure;
                SelectProfessor.CommandText = "SELECTPROFESSOR";
                ddProfessor.DataSource = db.GetDataSetUsingCmdObj(SelectProfessor);

                ddProfessor.DataValueField = "Professor_Id";
                ddProfessor.DataTextField = "professor_name";
                ddProfessor.DataBind();

                fillddCourses.CommandType = CommandType.StoredProcedure;
                fillddCourses.CommandText = "GetAllCourses";
                ddCourses.DataSource = db.GetDataSetUsingCmdObj(fillddCourses);

                ddCourses.DataValueField = "Course_Id";
                ddCourses.DataTextField = "Course_Name";
                ddCourses.DataBind();

               


            }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            ADDCOURSE.CommandType = CommandType.StoredProcedure;
            ADDCOURSE.CommandText = "ADDCOURSE";
            ADDCOURSE.Parameters.AddWithValue("@course", txtCourseID.Text);
            ADDCOURSE.Parameters.AddWithValue("@Dept_ID", ddDeptID.SelectedValue);
            ADDCOURSE.Parameters.AddWithValue("@CreditHours", txtCreditHours.Text);
            //ADDCOURSE.Parameters.AddWithValue("@semID", ddSemester.SelectedValue);
            ADDCOURSE.Parameters.AddWithValue("@courseName", txtCourseName.Text);
            ADDCOURSE.Parameters.AddWithValue("@desc", txtDesc.Text);
            db.DoUpdateUsingCmdObj(ADDCOURSE);
            DataBindSource();

            fillddCourses.CommandType = CommandType.StoredProcedure;
            fillddCourses.CommandText = "GetAllCourses";
            ddCourses.DataSource = db.GetDataSetUsingCmdObj(fillddCourses);

            ddCourses.DataValueField = "Course_Id";
            ddCourses.DataTextField = "Course_Name";
            ddCourses.DataBind();
        }

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            DELETECOURSE.CommandType = CommandType.StoredProcedure;
            DELETECOURSE.CommandText = "DELETECourse";
            DELETECOURSE.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
            db.DoUpdateUsingCmdObj(DELETECOURSE);
            DataBindSource();

            fillddCourses.CommandType = CommandType.StoredProcedure;
            fillddCourses.CommandText = "GetAllCourses";
            ddCourses.DataSource = db.GetDataSetUsingCmdObj(fillddCourses);

            ddCourses.DataValueField = "Course_Id";
            ddCourses.DataTextField = "Course_Name";
            ddCourses.DataBind();
        }

        protected void btnModifyCourse_Click(object sender, EventArgs e)
        {
            MODIFYCOURSE.CommandType = CommandType.StoredProcedure;
            MODIFYCOURSE.CommandText = "MODIFYCOURSE";
            MODIFYCOURSE.Parameters.AddWithValue("@CourseID", txtCourseID.Text);
            MODIFYCOURSE.Parameters.AddWithValue("@deptID", ddDeptID.SelectedValue);
            MODIFYCOURSE.Parameters.AddWithValue("@CreditHours", txtCreditHours.Text);
           // MODIFYCOURSE.Parameters.AddWithValue("@semID", ddSemester.SelectedValue);
            MODIFYCOURSE.Parameters.AddWithValue("@courseName", txtCourseName.Text);
            MODIFYCOURSE.Parameters.AddWithValue("@desc", txtDesc.Text);
            db.DoUpdateUsingCmdObj(MODIFYCOURSE);
            DataBindSource();
        }

        protected void btnAddSection_Click(object sender, EventArgs e)
        {
            ADDSection.CommandType = CommandType.StoredProcedure;
            ADDSection.CommandText = "ADDSECTION";
            ADDSection.Parameters.AddWithValue("@CRN", txtCRN.Text);
            ADDSection.Parameters.AddWithValue("@Class_days", txtDays.Text);
            ADDSection.Parameters.AddWithValue("@Class_time", txtTime.Text);
            ADDSection.Parameters.AddWithValue("@NumberSeatsAvaliable", txtSeats.Text);
            ADDSection.Parameters.AddWithValue("@MaxNumberOfSeats", txtMaxSeats.Text);
            ADDSection.Parameters.AddWithValue("@location", txtLocation.Text);
            ADDSection.Parameters.AddWithValue("@Semester_Id", ddSemester.SelectedValue);
            ADDSection.Parameters.AddWithValue("@Course_Id", ddCourses.SelectedValue);
            ADDSection.Parameters.AddWithValue("@Professor_Id", ddProfessor.SelectedValue);
            db.DoUpdateUsingCmdObj(ADDSection);

            DISPLAYSECTIONS.CommandType = CommandType.StoredProcedure;
            DISPLAYSECTIONS.CommandText = "DISPLAYSECTIONS";
            DISPLAYSECTIONS.Parameters.AddWithValue("@classId", ddCourses.SelectedValue);
            gvCourses.DataSource = db.GetDataSetUsingCmdObj(DISPLAYSECTIONS);
            gvCourses.DataBind();
        }

        protected void ddCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            DISPLAYSECTIONS.CommandType = CommandType.StoredProcedure;
            DISPLAYSECTIONS.CommandText = "DISPLAYSECTIONS";
            DISPLAYSECTIONS.Parameters.AddWithValue("@classId", ddCourses.SelectedValue);

            gvCourses.DataSource = db.GetDataSetUsingCmdObj(DISPLAYSECTIONS);
            gvCourses.DataBind();
        }

        protected void btnDeleteSection_Click(object sender, EventArgs e)
        {
            DELETESection.CommandType = CommandType.StoredProcedure;
            DELETESection.CommandText = "DELETESECTIONS";
            DELETESection.Parameters.AddWithValue("@CRN", txtCRN.Text);
            
            db.DoUpdateUsingCmdObj(DELETESection);

            DISPLAYSECTIONS.CommandType = CommandType.StoredProcedure;
            DISPLAYSECTIONS.CommandText = "DISPLAYSECTIONS";
            DISPLAYSECTIONS.Parameters.AddWithValue("@classId", ddCourses.SelectedValue);

            gvCourses.DataSource = db.GetDataSetUsingCmdObj(DISPLAYSECTIONS);
            gvCourses.DataBind();
        }

        protected void btnModifySection_Click(object sender, EventArgs e)
        {
            MODIFYSection.CommandType = CommandType.StoredProcedure;
            MODIFYSection.CommandText = "MODIFYSECTION";
            MODIFYSection.Parameters.AddWithValue("@CRN", txtCRN.Text);
            MODIFYSection.Parameters.AddWithValue("@Class_days", txtDays.Text);
            MODIFYSection.Parameters.AddWithValue("@Class_time", txtTime.Text);
            MODIFYSection.Parameters.AddWithValue("@NumberSeatsAvaliable", txtSeats.Text);
            MODIFYSection.Parameters.AddWithValue("@MaxNumberOfSeats", txtMaxSeats.Text);
            MODIFYSection.Parameters.AddWithValue("@location", txtLocation.Text);
            MODIFYSection.Parameters.AddWithValue("@Semester_Id", ddSemester.SelectedValue);
            MODIFYSection.Parameters.AddWithValue("@Course_Id", ddCourses.SelectedValue);
            MODIFYSection.Parameters.AddWithValue("@Professor_Id", ddProfessor.SelectedValue);
            db.DoUpdateUsingCmdObj(MODIFYSection);

            DISPLAYSECTIONS.CommandType = CommandType.StoredProcedure;
            DISPLAYSECTIONS.CommandText = "DISPLAYSECTIONS";
            DISPLAYSECTIONS.Parameters.AddWithValue("@classId", ddCourses.SelectedValue);
            gvCourses.DataSource = db.GetDataSetUsingCmdObj(DISPLAYSECTIONS);
            gvCourses.DataBind();
        }
    }
}