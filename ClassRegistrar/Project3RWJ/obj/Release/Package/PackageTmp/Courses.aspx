<%@ Page  Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="Project3RWJ.Courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/css/datepicker.css" rel="stylesheet" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
    <link rel="stylesheet" href="CSS.css" />
    <title></title>
    

</head>
<body>
    <form id="Courses" runat="server">
         <nav class="navbar navbar-default">
    <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="Index.aspx"><img src="Images/Temple_University_logo.png" alt="Temple" /></a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li class="active"><a href="Courses.aspx">Administrator<span class="sr-only">(current)</span></a></li>
        <li><a href="Registration.aspx">Registration</a></li>
      </ul>
      
     
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>

 <div class="container">
        <div class="row">
            <!-- col-sm-offset-3 -->
            
            <div class="col-lg-12 ">
                <h2></h2><br />
                    <div class="form-group">
                    <div id="Course" runat="server">
                        <div class="row">
                            <div class="col-xs-2">
                               <label id="lblCourse">Course_ID</label>
                                <asp:TextBox ID="txtCourseID" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <label id="lblDeptID">Dept</label>
                                <br />
                                <asp:DropDownList ID="ddDeptID" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                               <label id="lblCreditHours">Credit Hours:</label>
        
                               <asp:TextBox ID="txtCreditHours" class="form-control" runat="server"></asp:TextBox>
                                
        
                                
                            </div>
                             <div class="col-lg-2">
                               <label id="lblCourseName">Course Name:</label>
        
                               <asp:TextBox ID="txtCourseName" class="form-control" runat="server"></asp:TextBox>
                                
        
                            </div>
                            <div class="col-lg-2">
                              <label id="lblDesc">Description:</label>
        
                              <asp:TextBox ID="txtDesc" class="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                            <div class="col-lg-2">
                              <asp:Button ID="btnAddCourse" runat="server" Text="ADD" class="btn btn-default" OnClick="btnAddCourse_Click" />
                                <asp:Button ID="btnDeleteCourse" runat="server" Text="Delete"  class="btn btn-default" OnClick="btnDeleteCourse_Click"  />
                                <asp:Button ID="btnModifyCourse" runat="server" Text="Modify" class="btn btn-default" OnClick="btnModifyCourse_Click" />
                            </div>
                            
                        </div>
                        <br />
                       
                    </div> 
    
                    </div>
                 </div>
             </div>
        </div>

         <div class="container">
        <div class="row">
            <!-- col-sm-offset-3 -->
            
            <div class="col-lg-12 ">
                <h2></h2><br />
                    <div class="form-group">
                    <div id="Section" runat="server">
                        <div class="row">
                            <div class="col-xs-2">
                               <label id="lblCourseList">Course:</label>
                                <asp:DropDownList ID="ddCourses" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddCourses_SelectedIndexChanged"></asp:DropDownList>
                                <label id="lblSeats"># of Seats:</label>
                                
                                <asp:TextBox ID="txtSeats" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <label id="lblCRN">CRN</label>
                                
                                <asp:TextBox ID="txtCRN" class="form-control" runat="server"></asp:TextBox>
                                <label id="lblMaxSeats">Max Seats</label>
                                 
                                <asp:TextBox ID="txtMaxSeats" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                            <label id="lblClassDays">Days:</label>
                           
                            <asp:TextBox ID="txtDays" class="form-control" runat="server"></asp:TextBox>
                            <label id="lblLocation">Location:</label>
                           
                            <asp:TextBox ID="txtLocation" class="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                             <div class="col-lg-2">
                               <label id="lblTime">Times:</label>
                                <asp:TextBox ID="txtTime" class="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                            <div class="col-lg-2">
                              <label id="lblSemester">Semester:</label>
                                <br />
                                <asp:DropDownList ID="ddSemester" runat="server"></asp:DropDownList>
                                <br />
                             <label id="lblProfessor">Professor:</label>
                                <br />
                                <asp:DropDownList ID="ddProfessor" runat="server"></asp:DropDownList>
                                
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="btnAddSection" runat="server" class="btn btn-default" Text="Add Section" OnClick="btnAddSection_Click" />
                                <asp:Button ID="btnDeleteSection" runat="server" class="btn btn-default" Text="Delete Section" OnClick="btnDeleteSection_Click" />
                                <asp:Button ID="btnModifySection" runat="server" class="btn btn-default" Text="Modify Section" OnClick="btnModifySection_Click" />
                            </div>
                            
                        </div>
                        <br />
                        <br />

                      
                    </div> 
    
                    </div>
                 </div>
             </div>
        </div>

            <br />
        
        <center>
        <asp:GridView ID="gvCourses" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="42px" Width="1711px" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
         </center>
         <center>
        <footer class="footer" id="footer2" style="text-decoration: none">
            <div class="fixed-bottom">
            <div class="container">
                    Temple University © - <a href="https://www.temple.edu/">Temple University Site</a>
            </div>
                </div>
            </footer>
            </center>
    </form>
</body>
</html>
