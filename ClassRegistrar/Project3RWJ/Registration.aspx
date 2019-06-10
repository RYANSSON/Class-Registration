<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Project3RWJ.Registration" %>

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
    <form id="Registration" runat="server">
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
                    <div id="AddStudent" runat="server">
                        <div class="row">
                            <div class="col-xs-5">
                                <label for="lblName">Name:</label><asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                                <label for="lblMajor">Major:</label>
                                <asp:TextBox ID="txtMajor" class="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-5">
                                <label for="lblGPA">GPA:</label><asp:TextBox ID="txtGPA" class="form-control" runat="server"></asp:TextBox>
                                <label for="Address">Address:</label><asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                                
                            </div>
                            <div class="col-lg-2">
                                <br />
                                <center>
                                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-dark" Text="Register" OnClick="btnRegister_Click" />
                                    <br />
                                    <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Create Student" class="btn btn-default" OnClick="btnSubmit_Click" />
                                </center>
                                
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            <div class="col-md-1">
                                
                            </div>
                            <div class="col-md-8">
                                <p>
                            <label for="lblSearch">Search for courses:  Dept Name-</label>
                            <asp:DropDownList ID="ddDept"  runat="server" Height="17px" Width="160px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddSemester"  runat="server" Height="17px" Width="160px">
                            </asp:DropDownList>
                            <asp:Button ID="btnFilter" runat="server"  CssClass="btn btn-default" Text="Search" OnClick="btnFilter_Click" />
                            </p><center>
                                <asp:GridView ID="gvCourses" cssclass="table-bordered" runat="server" OnSelectedIndexChanged="gvCourses_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="239px" Width="906px">
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
                            </div>
                            <div class="col-md-1">
                                
                                
                            </div>
                           <div class="col-md-2">
                                
                                
                            </div>
                        </div>
                    </div>



       
        
        <div id="Register"  runat="server" visible="false">

             
                        <div class="row">
                            <div class="col-xs-2">
                            <asp:Button ID="btnViewCourses" runat="server" CssClass="btn btn-dark" Text="View Courses" OnClick="btnViewCourses_Click" />
                                <br />
                            <label id="lblID">ID: </label>
                            
                            <asp:Label ID="lblStudentID" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-xs-2">
                             
                            <label id="lblStudentIDReg" >Student ID:</label>
                            <br />
                                <label id="lblSName" >Name: </label>
                                
                                <asp:Label ID="lblStudentN" runat="server"   Text=""></asp:Label>
                                <label id="lblDept" >Department: </label>
                              
                                <asp:Label ID="lblStudentDept" runat="server"  Text=""></asp:Label>
                                

                                <br />
                            </div>

                            <div class="col-lg-4">
                              <asp:TextBox ID="txtID" class="form-control" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="ddRegSemester" runat="server">
                             </asp:DropDownList>
                            <asp:DropDownList ID="ddRegDept" runat="server">
                            </asp:DropDownList>
                               
                                
                            </div>
                            <div class="col-lg-4">
                              
                                 <asp:Button ID="btnviewSection" runat="server" cssclass="btn btn-default" Text="View Sections" OnClick="btnReg_Click" />


                                 <asp:Button ID="btnRoster" runat="server" cssclass="btn btn-default" Text="Review Student Roster" OnClick="btnRoster_Click" />
                            </div>
                        </div>
                        <br />
                        <br />

                        <div class="row">
                            
                            <div class="col-lg-12">
                                <div class="regGrid">
                           <center>
            <asp:GridView ID="gvCourseRegister" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvCourseRegister_RowDataBound"  Height="441px" Width="1100px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField HeaderText="CRN" DataField="CRN" />
                <asp:BoundField HeaderText="Course ID" DataField="Course_ID" />
                <asp:BoundField HeaderText="Course Name" DataField="Course_Name" />
                <asp:BoundField  HeaderText="Desciption" DataField="des" />
                <asp:BoundField  HeaderText="Seats Avaliable" DataField="NumberSeatsAvaliable"/>
                <asp:BoundField HeaderText="Maximimum Seats" DataField="MaxNumberOfSeats" />
                <asp:BoundField HeaderText="Credit Hours" DataField="CreditHours" />
                <asp:BoundField HeaderText="Days" DataField="Class_days" />
                <asp:BoundField  HeaderText="Times" DataField="Class_time"/>
                <asp:BoundField  HeaderText="Professor" DataField="professor_name"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblOpen" runat="server" Text="Blank"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEnroll" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
                
            <asp:GridView ID="gvRoster" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="217px" Width="1100px">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox id="chkDrop" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>
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
                
        <asp:Button ID="btnRegisterStudent" runat="server" Text="Register" cssclass="btn btn-default" OnClick="btnRegisterStudent_Click" />
            <asp:Button ID="btnDROP" runat="server" Text="DROP Sections" cssclass="btn btn-default" OnClick="btnDROP_Click" />
                </center>
                                    </div>
                            </div>
                            
                        </div>

            </div>
           
           




            </div>
            </div>

           

            
            

            </div>
        </div>
        


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
