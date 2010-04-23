using NUnit.Framework;
using SchemaValidator;
using SchemaValidator.DbProviders;

namespace DatabaseTests { 

    [TestFixture]
    public class DbSchemaTests {
        private DbSpecification _dbSpecification;

        [TestFixtureSetUp]
        public void SetUp() {
            // Arrange 
            var dbProvider = new SqlSrvProvider("Data Source=mfstest;Initial Catalog=fosmaster;User ID=momentis;Password=HGDHSWGWYIBWGQDIJSGXDHZSGSRHXA;");
            _dbSpecification = dbProvider.LoadDbSpecification();
        }


        [Test]
        public void _Agent_Users_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Agent_Users")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("Agent_Cd").OfType("varchar", 2)
                .WithColumn("Agent_Users").OfType("varchar", 30)
                .WithColumn("Agent_Passwd").OfType("Description", 30)
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Users_NT_Account").OfType("varchar", 200).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ChannelDetail1_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ChannelDetail1")
                .WithColumn("CHID").OfType("char", 3).Nullable()
                .WithColumn("CD1ID").OfType("char", 3).Nullable()
                .WithColumn("CD1Href").OfType("varchar", 255).Nullable()
                .WithColumn("CD1PreCache").OfType("varchar", 255).Nullable()
                .WithColumn("CD1Title").OfType("varchar", 255).Nullable()
                .WithColumn("CD1Abstract").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ChannelDetail2_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ChannelDetail2")
                .WithColumn("CHID").OfType("char", 3).Nullable()
                .WithColumn("CD1ID").OfType("char", 3).Nullable()
                .WithColumn("CD2ID").OfType("char", 3).Nullable()
                .WithColumn("CD2Href").OfType("varchar", 255).Nullable()
                .WithColumn("CD2PreCache").OfType("varchar", 255).Nullable()
                .WithColumn("CD2Title").OfType("varchar", 255).Nullable()
                .WithColumn("CD2Abstract").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ChannelHeader_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ChannelHeader")
                .WithColumn("CHID").OfType("char", 3).Nullable()
                .WithColumn("CHTitle").OfType("Description", 30).Nullable()
                .WithColumn("CHHref").OfType("varchar", 255).Nullable()
                .WithColumn("CHPreCache").OfType("varchar", 30).Nullable()
                .WithColumn("CHBase").OfType("varchar", 255).Nullable()
                .WithColumn("CHAbstract").OfType("varchar", 255).Nullable()
                .WithColumn("CHLogoIcon").OfType("varchar", 255).Nullable()
                .WithColumn("CHLogoImage").OfType("varchar", 255).Nullable()
                .WithColumn("CHLogoImageWide").OfType("varchar", 255).Nullable()
                .WithColumn("CHSchedule").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Company_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Company")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Address").OfType("varchar", 30).Nullable()
                .WithColumn("Suite").OfType("varchar", 30).Nullable()
                .WithColumn("City").OfType("varchar", 30).Nullable()
                .WithColumn("State").OfType("varchar", 30).Nullable()
                .WithColumn("Country").OfType("varchar", 30).Nullable()
                .WithColumn("PostalCode").OfType("varchar", 10).Nullable()
                .WithColumn("Phone").OfType("varchar", 10).Nullable()
                .WithColumn("Fax").OfType("varchar", 10).Nullable()
                .WithColumn("DatabaseName").OfType("varchar", 255).Nullable()
                .WithColumn("Connect").OfType("varchar", 255).Nullable()
                .WithColumn("Display_YN").OfType("int", 4).Nullable()
                .WithColumn("Logo_Picture").OfType("Misc60", 60).Nullable()
                .WithColumn("GST_No").OfType("varchar", 18).Nullable()
                .WithColumn("PST_No").OfType("varchar", 18).Nullable()
                .WithColumn("HST_No").OfType("varchar", 18).Nullable()
                .WithColumn("Duns_No").OfType("varchar", 16).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Company_Group_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Company_Group")
                .WithColumn("CompanyNo").OfType("varchar", 4)
                .WithColumn("Company_Group_cd").OfType("varchar", 2);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Company_Profile_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Company_Profile")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("Users_No").OfType("char", 3)
                .WithColumn("Button_Context").OfType("varchar", 60)
                .WithColumn("Sequence").OfType("int", 4)
                .WithColumn("Button_Name").OfType("varchar", 60)
                .WithColumn("Button_Tool_Tip_Text").OfType("varchar", 255)
                .WithColumn("Target_ASP_Name").OfType("varchar", 60)
                .WithColumn("Image_On_Name").OfType("varchar", 60)
                .WithColumn("Image_Off_Name").OfType("varchar", 60);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Company_View_Dependencies_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Company_View_Dependencies")
                .WithColumn("Table_CompanyNo").OfType("char", 4)
                .WithColumn("View_CompanyNo").OfType("char", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Constant_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Constant")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("Season_No").OfType("char", 4)
                .WithColumn("Division_No").OfType("char", 2)
                .WithColumn("Language_Cd").OfType("char", 2).Nullable()
                .WithColumn("Country_Cd").OfType("char", 3).Nullable()
                .WithColumn("Currencies_Cd").OfType("char", 3).Nullable()
                .WithColumn("UPC_Dealer_Cd").OfType("char", 5).Nullable()
                .WithColumn("Tax_Cd").OfType("char", 3).Nullable()
                .WithColumn("Default_Order_Type").OfType("char", 2).Nullable()
                .WithColumn("Automatic_UPC_Creation_YN").OfType("bit", 1)
                .WithColumn("Break_On_Error_YN").OfType("bit", 1)
                .WithColumn("Allow_Multiple_Season_YN").OfType("bit", 1)
                .WithColumn("Retail_Mkup_Active_YN").OfType("bit", 1)
                .WithColumn("Style1_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style1_Label").OfType("varchar", 10).Nullable()
                .WithColumn("Style2_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style2_Label").OfType("varchar", 10).Nullable()
                .WithColumn("Style3_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style3_Label").OfType("varchar", 10).Nullable()
                .WithColumn("DayEndMachPath").OfType("varchar", 255).Nullable()
                .WithColumn("CorrespondancePath").OfType("varchar", 255).Nullable()
                .WithColumn("PrinterListPath").OfType("varchar", 255).Nullable()
                .WithColumn("ODBCString").OfType("varchar", 255).Nullable()
                .WithColumn("LastCustomerNo").OfType("float", 8).Nullable()
                .WithColumn("LastOrderNo").OfType("float", 8).Nullable()
                .WithColumn("LastInvoiceNo").OfType("float", 8).Nullable()
                .WithColumn("LastVendorNo").OfType("float", 8).Nullable()
                .WithColumn("ReportsPath").OfType("varchar", 255).Nullable()
                .WithColumn("StylePicturesPath").OfType("varchar", 255).Nullable()
                .WithColumn("DAO_ODBC").OfType("varchar", 255).Nullable()
                .WithColumn("RDO_ODBC").OfType("varchar", 255).Nullable()
                .WithColumn("DatabaseName").OfType("varchar", 30).Nullable()
                .WithColumn("LastWipNo").OfType("int", 4).Nullable()
                .WithColumn("Allo_Default_Status").OfType("char", 2).Nullable()
                .WithColumn("RootDirectory").OfType("char", 255).Nullable()
                .WithColumn("WIP_Visible_YN").OfType("Yes_No", 1)
                .WithColumn("CDF_Path").OfType("varchar", 255).Nullable()
                .WithColumn("Channel_HTM").OfType("varchar", 255).Nullable()
                .WithColumn("Http_Path").OfType("varchar", 255).Nullable()
                .WithColumn("ExcelPath").OfType("varchar", 60).Nullable()
                .WithColumn("CabPath").OfType("varchar", 60).Nullable()
                .WithColumn("CurrFiscalYear").OfType("varchar", 4).Nullable()
                .WithColumn("LyCurrFiscal").OfType("varchar", 4).Nullable()
                .WithColumn("CurrentPeriod").OfType("Quantity", 8).Nullable()
                .WithColumn("ServerName").OfType("varchar", 64)
                .WithColumn("Password").OfType("varchar", 64);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Constant_tmp_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Constant_tmp")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("Season_No").OfType("char", 4)
                .WithColumn("Division_No").OfType("char", 2)
                .WithColumn("Language_Cd").OfType("char", 2).Nullable()
                .WithColumn("Country_Cd").OfType("char", 3).Nullable()
                .WithColumn("Currencies_Cd").OfType("char", 3).Nullable()
                .WithColumn("UPC_Dealer_Cd").OfType("char", 5).Nullable()
                .WithColumn("Tax_Cd").OfType("char", 3).Nullable()
                .WithColumn("Default_Order_Type").OfType("char", 2).Nullable()
                .WithColumn("Automatic_UPC_Creation_YN").OfType("bit", 1)
                .WithColumn("Break_On_Error_YN").OfType("bit", 1)
                .WithColumn("Allow_Multiple_Season_YN").OfType("bit", 1)
                .WithColumn("Retail_Mkup_Active_YN").OfType("bit", 1)
                .WithColumn("Style1_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style1_Label").OfType("varchar", 10).Nullable()
                .WithColumn("Style2_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style2_Label").OfType("varchar", 10).Nullable()
                .WithColumn("Style3_Len").OfType("smallint", 2).Nullable()
                .WithColumn("Style3_Label").OfType("varchar", 10).Nullable()
                .WithColumn("DayEndMachPath").OfType("varchar", 255).Nullable()
                .WithColumn("CorrespondancePath").OfType("varchar", 255).Nullable()
                .WithColumn("PrinterListPath").OfType("varchar", 255).Nullable()
                .WithColumn("ODBCString").OfType("varchar", 255).Nullable()
                .WithColumn("LastCustomerNo").OfType("float", 8).Nullable()
                .WithColumn("LastOrderNo").OfType("float", 8).Nullable()
                .WithColumn("LastInvoiceNo").OfType("float", 8).Nullable()
                .WithColumn("LastVendorNo").OfType("float", 8).Nullable()
                .WithColumn("ReportsPath").OfType("varchar", 255).Nullable()
                .WithColumn("StylePicturesPath").OfType("varchar", 255).Nullable()
                .WithColumn("DAO_ODBC").OfType("varchar", 255).Nullable()
                .WithColumn("RDO_ODBC").OfType("varchar", 255).Nullable()
                .WithColumn("DatabaseName").OfType("varchar", 30).Nullable()
                .WithColumn("LastWipNo").OfType("int", 4).Nullable()
                .WithColumn("Allo_Default_Status").OfType("char", 2).Nullable()
                .WithColumn("RootDirectory").OfType("char", 255).Nullable()
                .WithColumn("WIP_Visible_YN").OfType("Yes_No", 1)
                .WithColumn("CDF_Path").OfType("varchar", 255).Nullable()
                .WithColumn("Channel_HTM").OfType("varchar", 255).Nullable()
                .WithColumn("Http_Path").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _CounterInt_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_CounterInt")
                .WithColumn("Counter_ID").OfType("varchar", 30)
                .WithColumn("Counter_Value").OfType("int", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Default_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Default")
                .WithColumn("TableName").OfType("varchar", 50)
                .WithColumn("FieldName").OfType("varchar", 50)
                .WithColumn("DefaultValue").OfType("varchar", 50).Nullable()
                .WithColumn("DefaultType").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Department_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Department")
                .WithColumn("DeptNo").OfType("varchar", 3)
                .WithColumn("DeptName").OfType("varchar", 30);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Hierarchy_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Hierarchy")
                .WithColumn("DeptNo").OfType("varchar", 3)
                .WithColumn("RootParent").OfType("varchar", 5).Nullable()
                .WithColumn("RootChild").OfType("varchar", 5)
                .WithColumn("UserNo").OfType("varchar", 3);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Job_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Job")
                .WithColumn("Job_No").OfType("varchar", 50)
                .WithColumn("Submitted_By").OfType("varchar", 50)
                .WithColumn("Date_Stamp").OfType("datetime", 8)
                .WithColumn("Job_Status").OfType("varchar", 1)
                .WithColumn("Job_Reference").OfType("varchar", 50).Nullable()
                .WithColumn("SessionNo").OfType("int", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _LogMenu_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_LogMenu")
                .WithColumn("EntryID").OfType("int", 4)
                .WithColumn("EntryDateTime").OfType("datetime", 8)
                .WithColumn("UserName").OfType("varchar", 100)
                .WithColumn("PgmName").OfType("varchar", 500);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Machine_User_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Machine_User")
                .WithColumn("Machine_User_ID").OfType("int", 4)
                .WithColumn("Machine_User_Desc").OfType("varchar", 100);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Message_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Message")
                .WithColumn("Message_No").OfType("int", 4)
                .WithColumn("Message_Buttons").OfType("int", 4).Nullable()
                .WithColumn("Message_Title").OfType("varchar", 255).Nullable()
                .WithColumn("Message_Prompt").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ModuleAssembly_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ModuleAssembly")
                .WithColumn("Module_Assembly_ID").OfType("int", 4)
                .WithColumn("Module_Assembly_File").OfType("varchar", 255)
                .WithColumn("Module_Assembly_Friendly_Name").OfType("varchar", 255).Nullable()
                .WithColumn("Module_Assembly_Update_Location").OfType("varchar", 255);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Printer_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Printer")
                .WithColumn("Printer_ID").OfType("int", 4)
                .WithColumn("Printer_Desc").OfType("varchar", 60)
                .WithColumn("Printer_Name").OfType("varchar", 255).Nullable()
                .WithColumn("Printer_Driver").OfType("varchar", 255).Nullable()
                .WithColumn("PrinterPort").OfType("varchar", 255).Nullable()
                .WithColumn("Excel_Printer_Name").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _RepAction_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_RepAction")
                .WithColumn("ActionName").OfType("Description", 30)
                .WithColumn("ActionDesc").OfType("Description", 30).Nullable()
                .WithColumn("LockYN").OfType("bit", 1);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _RepCall_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_RepCall")
                .WithColumn("ActionName").OfType("Description", 30)
                .WithColumn("SeqNo").OfType("int", 4)
                .WithColumn("ObjectName").OfType("Description", 30)
                .WithColumn("Statement1").OfType("varchar", 255).Nullable()
                .WithColumn("StatementType").OfType("char", 1).Nullable()
                .WithColumn("Statement").OfType("varchar", 8000).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _RepCall_Telio_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_RepCall_Telio")
                .WithColumn("ActionName").OfType("Description", 30)
                .WithColumn("SeqNo").OfType("int", 4)
                .WithColumn("ObjectName").OfType("Description", 30)
                .WithColumn("Statement1").OfType("varchar", 255).Nullable()
                .WithColumn("StatementType").OfType("char", 1).Nullable()
                .WithColumn("Statement").OfType("text", 16).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _RepObject_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_RepObject")
                .WithColumn("ObjectName").OfType("Description", 30)
                .WithColumn("ObjectDesc").OfType("Description", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Report_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Report")
                .WithColumn("ReportName").OfType("varchar", 30)
                .WithColumn("FileName").OfType("varchar", 255)
                .WithColumn("TableName").OfType("varchar", 30)
                .WithColumn("ReportTitle").OfType("varchar", 50).Nullable()
                .WithColumn("SQLStatement").OfType("text", 16).Nullable()
                .WithColumn("_ReportType").OfType("char", 2).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportLinks_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportLinks")
                .WithColumn("ReportName").OfType("varchar", 30)
                .WithColumn("TableName").OfType("varchar", 30)
                .WithColumn("FieldName").OfType("varchar", 30)
                .WithColumn("LinkedTable").OfType("varchar", 30)
                .WithColumn("LinkedField").OfType("varchar", 30)
                .WithColumn("Comments").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportList_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportList")
                .WithColumn("Report_No").OfType("int", 4)
                .WithColumn("Report_Name").OfType("varchar", 60)
                .WithColumn("Report_Description").OfType("varchar", 60).Nullable()
                .WithColumn("Report_Attribute").OfType("varchar", 30).Nullable()
                .WithColumn("SpToRun").OfType("varchar", 60).Nullable()
                .WithColumn("SelectString").OfType("text", 16).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportMenu_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportMenu")
                .WithColumn("ReportTopic").OfType("Description", 30)
                .WithColumn("ReportName").OfType("varchar", 30)
                .WithColumn("ParentKey").OfType("char", 3).Nullable()
                .WithColumn("ChildKey").OfType("char", 3).Nullable()
                .WithColumn("FormToCall").OfType("char", 255).Nullable()
                .WithColumn("Source").OfType("char", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportPrinter_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportPrinter")
                .WithColumn("Printer_Name").OfType("varchar", 50).Nullable()
                .WithColumn("Printer_Port").OfType("varchar", 50).Nullable()
                .WithColumn("Printer_Driver").OfType("varchar", 50).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportSelc_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportSelc")
                .WithColumn("NT_LoginName").OfType("Misc60", 60)
                .WithColumn("_ReportType").OfType("char", 2)
                .WithColumn("Rpt_ID").OfType("LineNum", 4)
                .WithColumn("Rpt_Desc").OfType("Description", 30).Nullable()
                .WithColumn("Rpt_DateCreated").OfType("datetime", 8).Nullable()
                .WithColumn("Rpt_FTID1").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID2").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID3").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID4").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID5").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID6").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID7").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID8").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID9").OfType("SerialNo", 4)
                .WithColumn("Rpt_FTID0").OfType("SerialNo", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportType_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportType")
                .WithColumn("_ReportType").OfType("char", 2)
                .WithColumn("_ReportDesc").OfType("Description", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _ReportUCaf_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_ReportUCaf")
                .WithColumn("_ReportType").OfType("char", 2)
                .WithColumn("UCaf_ID").OfType("SerialNo", 4)
                .WithColumn("UCAFCaption_Name").OfType("Description", 30).Nullable()
                .WithColumn("UCAFTable_Name").OfType("Description", 30).Nullable()
                .WithColumn("UCAFCol_Name").OfType("Description", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Server_Setting_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Server_Setting")
                .WithColumn("Entity_ID").OfType("int", 4).Nullable()
                .WithColumn("Users_No").OfType("varchar", 3).Nullable()
                .WithColumn("Module_ID").OfType("int", 4).Nullable()
                .WithColumn("Setting_Name").OfType("varchar", 60)
                .WithColumn("Setting_Value").OfType("varchar", 8000);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Session_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Session")
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("Username").OfType("Description", 30)
                .WithColumn("Password").OfType("Description", 30)
                .WithColumn("Connect").OfType("varchar", 255).Nullable()
                .WithColumn("CreationDateTime").OfType("datetime", 8).Nullable()
                .WithColumn("CompanyNo").OfType("char", 2).Nullable()
                .WithColumn("LoginName").OfType("varchar", 64).Nullable()
                .WithColumn("TerminalDate").OfType("datetime", 8).Nullable()
                .WithColumn("Users_No").OfType("char", 3).Nullable()
                .WithColumn("DBName").OfType("varchar", 50).Nullable()
                .WithColumn("ConnectODBC").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _SessionLink_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_SessionLink")
                .WithColumn("SessionNo").OfType("int", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Transfer_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Transfer")
                .WithColumn("TableName").OfType("varchar", 50)
                .WithColumn("ExportYN").OfType("Yes_No", 1);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Tree_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Tree")
                .WithColumn("RootParent").OfType("varchar", 5).Nullable()
                .WithColumn("SectionKey").OfType("varchar", 5)
                .WithColumn("SectionName").OfType("varchar", 30).Nullable()
                .WithColumn("ItemIcon").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Users_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Users")
                .WithColumn("Users_No").OfType("char", 3)
                .WithColumn("Users_Name").OfType("varchar", 30)
                .WithColumn("Users_Extension").OfType("varchar", 5)
                .WithColumn("Users_EMail_Address").OfType("varchar", 50)
                .WithColumn("Users_Terminal_Date").OfType("datetime", 8)
                .WithColumn("Users_Group_No").OfType("char", 3)
                .WithColumn("Security_Group_No").OfType("char", 3)
                .WithColumn("Users_Icon").OfType("varchar", 30)
                .WithColumn("OnHierarchy_YN").OfType("bit", 1)
                .WithColumn("DeptNo").OfType("varchar", 3)
                .WithColumn("Season_No").OfType("varchar", 4)
                .WithColumn("CompanyNo").OfType("varchar", 4)
                .WithColumn("Division_No").OfType("varchar", 2)
                .WithColumn("User_Password").OfType("varchar", 1000)
                .WithColumn("UserCustomer_No").OfType("varchar", 6)
                .WithColumn("Users_ExchangeAccount").OfType("varchar", 50)
                .WithColumn("Salesman_Cd").OfType("varchar", 2)
                .WithColumn("Gen_SFA_DB_YN").OfType("Yes_No", 1)
                .WithColumn("Behavior_Cd").OfType("varchar", 10)
                .WithColumn("Signature_Bitmap").OfType("varchar", 50)
                .WithColumn("Country_Cd_MFG").OfType("varchar", 3)
                .WithColumn("PrintPrepack").OfType("bit", 1)
                .WithColumn("Starting_ASP").OfType("varchar", 200).Nullable()
                .WithColumn("Open_Approved_Orders_Allowed_YN").OfType("bit", 1)
                .WithColumn("OWC_Version").OfType("varchar", 255)
                .WithColumn("Remote_User_YN").OfType("bit", 1)
                .WithColumn("Scanner_ReceivingPosting_Allowed_YN").OfType("bit", 1)
                .WithColumn("Manager_Users_No").OfType("char", 3).Nullable()
                .WithColumn("Users_NT_Account").OfType("varchar", 200)
                .WithColumn("CustomerService_YN").OfType("Yes_No", 1)
                .WithColumn("Salesman_Hierarchy_ID").OfType("int", 4).Nullable()
                .WithColumn("Restrict_Data_Based_On_Salesman_YN").OfType("Yes_No", 1).Nullable()
                .WithColumn("Default_Order_Catg_Cd").OfType("varchar", 2).Nullable()
                .WithColumn("Default_Order_Type_Cd").OfType("varchar", 2).Nullable()
                .WithColumn("Auto_allo_Type").OfType("varchar", 1).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _UsersGroup_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_UsersGroup")
                .WithColumn("UsersGroup_No").OfType("char", 3)
                .WithColumn("UsersGroup_Desc").OfType("varchar", 30)
                .WithColumn("Price1_YN").OfType("Yes_No", 1)
                .WithColumn("Price2_YN").OfType("Yes_No", 1)
                .WithColumn("Price3_YN").OfType("Yes_No", 1)
                .WithColumn("Price4_YN").OfType("Yes_No", 1)
                .WithColumn("FirstCost_YN").OfType("Yes_No", 1)
                .WithColumn("EstmCost_YN").OfType("Yes_No", 1)
                .WithColumn("LstAvgCost_YN").OfType("Yes_No", 1)
                .WithColumn("InvtCost_YN").OfType("Yes_No", 1)
                .WithColumn("AvgPrice_YN").OfType("Yes_No", 1)
                .WithColumn("AvgCost_YN").OfType("Yes_No", 1)
                .WithColumn("LCFactor_YN").OfType("Yes_No", 1)
                .WithColumn("ViewCost_YN").OfType("Yes_No", 1)
                .WithColumn("Markdown_YN").OfType("Yes_No", 1)
                .WithColumn("ViewPO_YN").OfType("Yes_No", 1)
                .WithColumn("MenuFileName").OfType("varchar", 60);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _UsersGroupOld_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_UsersGroupOld")
                .WithColumn("UsersGroup_No").OfType("char", 3)
                .WithColumn("UsersGroup_Desc").OfType("varchar", 30).Nullable()
                .WithColumn("Users_No").OfType("char", 3).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void _Vendor_Users_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("_Vendor_Users")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("Vendor_No").OfType("varchar", 6)
                .WithColumn("Vendor_Users").OfType("varchar", 30)
                .WithColumn("Vendor_Passwd").OfType("varchar", 30)
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Users_NT_Account").OfType("varchar", 200).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void aaa_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("aaa")
                .WithColumn("job_no").OfType("int", 4)
                .WithColumn("Connect").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void ActualCostSheetDetail_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("ActualCostSheetDetail")
                .WithColumn("SessionNo").OfType("Session", 4)
                .WithColumn("ShipmentNo").OfType("varchar", 18)
                .WithColumn("Po_No").OfType("varchar", 7)
                .WithColumn("Po_LineNo").OfType("int", 4)
                .WithColumn("Po_LineNo_ShipNo").OfType("int", 4)
                .WithColumn("Detail_Catg_Cd").OfType("int", 4).Nullable()
                .WithColumn("Detail_Catg_Desc").OfType("varchar", 30).Nullable()
                .WithColumn("Item_Cd").OfType("varchar", 30).Nullable()
                .WithColumn("Item_Desc").OfType("varchar", 30).Nullable()
                .WithColumn("Actual_Cost").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Catalogue_Printing_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Catalogue_Printing")
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("Printing_Seq").OfType("int", 4)
                .WithColumn("Style1").OfType("char", 10).Nullable()
                .WithColumn("Style2").OfType("char", 8).Nullable()
                .WithColumn("StyleColor").OfType("char", 6).Nullable()
                .WithColumn("Customer_No").OfType("char", 6).Nullable()
                .WithColumn("Price1").OfType("Dollar", 8).Nullable()
                .WithColumn("Price2").OfType("Dollar", 8).Nullable()
                .WithColumn("Picture_Name").OfType("varchar", 255).Nullable()
                .WithColumn("PageBreak_YN").OfType("Yes_No", 1).Nullable()
                .WithColumn("CompanyNo").OfType("char", 4).Nullable()
                .WithColumn("OrderNo").OfType("char", 7).Nullable()
                .WithColumn("OrderLine_No").OfType("int", 4).Nullable()
                .WithColumn("Job_No").OfType("varchar", 50).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Catalogue_Printing2_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Catalogue_Printing2")
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("Printing_Seq").OfType("int", 4)
                .WithColumn("Style1").OfType("char", 10).Nullable()
                .WithColumn("Style2").OfType("char", 8).Nullable()
                .WithColumn("StyleColor").OfType("char", 6).Nullable()
                .WithColumn("Customer_No").OfType("char", 6).Nullable()
                .WithColumn("Avg_Selling_Price").OfType("Dollar", 8).Nullable()
                .WithColumn("Min_Selling_Price").OfType("Dollar", 8).Nullable()
                .WithColumn("Lvl1_Selling_Price").OfType("Dollar", 8).Nullable()
                .WithColumn("Net_Sales").OfType("Dollar", 8).Nullable()
                .WithColumn("Gross_Sales").OfType("Dollar", 8).Nullable()
                .WithColumn("Qty_Sold").OfType("Dollar", 8).Nullable()
                .WithColumn("Picture_Name").OfType("varchar", 255).Nullable()
                .WithColumn("PageBreak_YN").OfType("Yes_No", 1).Nullable()
                .WithColumn("CompanyNo").OfType("char", 4).Nullable()
                .WithColumn("Job_No").OfType("varchar", 50).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetDanier_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetDanier")
                .WithColumn("Source_ID").OfType("char", 3)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("Title").OfType("varchar", 18).Nullable()
                .WithColumn("ETD").OfType("datetime", 8).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Description").OfType("varchar", 60).Nullable()
                .WithColumn("Season_No").OfType("varchar", 4).Nullable()
                .WithColumn("Country_cd").OfType("varchar", 3).Nullable()
                .WithColumn("UM_Buying").OfType("varchar", 4).Nullable()
                .WithColumn("Vendor_No").OfType("varchar", 6).Nullable()
                .WithColumn("Vendor_Factory").OfType("varchar", 6).Nullable()
                .WithColumn("Merchandiser_Cd").OfType("varchar", 2).Nullable()
                .WithColumn("Agent_Cd").OfType("varchar", 2).Nullable()
                .WithColumn("Silhouette_Cd").OfType("varchar", 10).Nullable()
                .WithColumn("Size_Cd").OfType("varchar", 2)
                .WithColumn("FobCity_Cd").OfType("varchar", 10).Nullable()
                .WithColumn("Currencies_Cd").OfType("varchar", 3).Nullable()
                .WithColumn("Style_ID").OfType("int", 4)
                .WithColumn("Style_First_Cost").OfType("money", 8)
                .WithColumn("Terms_Cd").OfType("varchar", 3).Nullable()
                .WithColumn("Freight_cd").OfType("varchar", 3).Nullable()
                .WithColumn("Org_Retail").OfType("money", 8).Nullable()
                .WithColumn("Current_Retail").OfType("money", 8).Nullable()
                .WithColumn("cstCurrencies_Cd").OfType("varchar", 3).Nullable()
                .WithColumn("FromCurrencies").OfType("varchar", 3).Nullable()
                .WithColumn("FinGood_RawMat_FR").OfType("char", 1).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetFG000_699_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetFG000_699")
                .WithColumn("Source_ID").OfType("char", 3)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("FixPerc").OfType("varchar", 2)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Value").OfType("float", 8).Nullable()
                .WithColumn("CostCode_Amount").OfType("money", 8)
                .WithColumn("FirstCostCountry").OfType("float", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetFG700_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetFG700")
                .WithColumn("Source_ID").OfType("char", 3)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("IMU_Perc").OfType("money", 8)
                .WithColumn("Suggest_Retail").OfType("Dollar", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetRM001_200_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetRM001_200")
                .WithColumn("Source_ID").OfType("varchar", 1)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Value").OfType("money", 8)
                .WithColumn("CostCode_Amount").OfType("money", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetRM200_400_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetRM200_400")
                .WithColumn("Source_ID").OfType("varchar", 1)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Value").OfType("money", 8)
                .WithColumn("CostCode_Amount").OfType("money", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetRM400_600_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetRM400_600")
                .WithColumn("Source_ID").OfType("varchar", 1)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Value").OfType("money", 8)
                .WithColumn("CostCode_Amount").OfType("money", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostSheetRM700_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostSheetRM700")
                .WithColumn("Source_ID").OfType("varchar", 1)
                .WithColumn("Ref_ID").OfType("int", 4)
                .WithColumn("To_Country_Cd").OfType("varchar", 25).Nullable()
                .WithColumn("EstimatedSellingCost").OfType("float", 8).Nullable()
                .WithColumn("CostCodeDefault").OfType("float", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void CostVarDetail_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("CostVarDetail")
                .WithColumn("SessionNo").OfType("Session", 4)
                .WithColumn("ShipmentNo").OfType("varchar", 18)
                .WithColumn("Po_No").OfType("varchar", 7)
                .WithColumn("Po_LineNo").OfType("int", 4)
                .WithColumn("Po_LineNo_ShipNo").OfType("int", 4)
                .WithColumn("Detail_Catg_Cd").OfType("int", 4).Nullable()
                .WithColumn("Detail_Catg_Desc").OfType("varchar", 30).Nullable()
                .WithColumn("Item_Cd").OfType("varchar", 30).Nullable()
                .WithColumn("Item_Desc").OfType("varchar", 120).Nullable()
                .WithColumn("Estimated_Cost").OfType("money", 8).Nullable()
                .WithColumn("Actual_Cost").OfType("money", 8).Nullable()
                .WithColumn("Var_Amount").OfType("money", 8).Nullable()
                .WithColumn("Var_Perc").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Cutting_detail_WF_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Cutting_detail_WF")
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("Cutting_No").OfType("varchar", 7)
                .WithColumn("Cutting_LineNo").OfType("int", 4)
                .WithColumn("Operation1").OfType("varchar", 30).Nullable()
                .WithColumn("Operation2").OfType("varchar", 30).Nullable()
                .WithColumn("Operation3").OfType("varchar", 30).Nullable()
                .WithColumn("Operation4").OfType("varchar", 30).Nullable()
                .WithColumn("Operation5").OfType("varchar", 30).Nullable()
                .WithColumn("Operation6").OfType("varchar", 30).Nullable()
                .WithColumn("Operation7").OfType("varchar", 30).Nullable()
                .WithColumn("Operation8").OfType("varchar", 30).Nullable()
                .WithColumn("Operation9").OfType("varchar", 30).Nullable()
                .WithColumn("Operation10").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation1").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation2").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation3").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation4").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation5").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation6").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation7").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation8").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation9").OfType("varchar", 30).Nullable()
                .WithColumn("Color_Operation10").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void dtproperties_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("dtproperties")
                .WithColumn("id").OfType("int", 4)
                .WithColumn("objectid").OfType("int", 4).Nullable()
                .WithColumn("property").OfType("varchar", 64)
                .WithColumn("value").OfType("varchar", 255).Nullable()
                .WithColumn("lvalue").OfType("image", 16).Nullable()
                .WithColumn("version").OfType("int", 4)
                .WithColumn("uvalue").OfType("nvarchar", 510).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void DTS_Exec_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("DTS_Exec")
                .WithColumn("Package_ID").OfType("Package_ID", 10)
                .WithColumn("Exec_ID").OfType("int", 4)
                .WithColumn("DBName").OfType("varchar", 30)
                .WithColumn("SuccessStatus").OfType("bit", 1).Nullable()
                .WithColumn("job_id").OfType("uniqueidentifier", 16).Nullable()
                .WithColumn("last_step_id").OfType("int", 4).Nullable()
                .WithColumn("Exec_Dte").OfType("datetime", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void DTS_Package_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("DTS_Package")
                .WithColumn("Package_ID").OfType("Package_ID", 10)
                .WithColumn("Package_Name").OfType("varchar", 30);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void DTS_Param_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("DTS_Param")
                .WithColumn("Package_ID").OfType("Package_ID", 10)
                .WithColumn("Exec_ID").OfType("int", 4)
                .WithColumn("Param_Name").OfType("varchar", 20)
                .WithColumn("Param_Value").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Edi_850_Job_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Edi_850_Job")
                .WithColumn("Edi_Transmission_ID").OfType("int", 4)
                .WithColumn("Users_No").OfType("char", 3)
                .WithColumn("Company_No").OfType("char", 4)
                .WithColumn("Users_EMail_Address").OfType("varchar", 50);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void EDI_ToProcess_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("EDI_ToProcess")
                .WithColumn("Transmission_No").OfType("int", 4)
                .WithColumn("EDI_No").OfType("varchar", 50)
                .WithColumn("File_Path").OfType("varchar", 300)
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("Status_Cd").OfType("varchar", 2)
                .WithColumn("Email_Summary").OfType("bit", 1)
                .WithColumn("Email_Separate").OfType("bit", 1)
                .WithColumn("Created_Dte").OfType("datetime", 8)
                .WithColumn("Completed_Dte").OfType("datetime", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void EDISenderReceiverMaster_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("EDISenderReceiverMaster")
                .WithColumn("Sender_ID").OfType("varchar", 20)
                .WithColumn("Receiver_ID").OfType("varchar", 20)
                .WithColumn("Dept_No").OfType("varchar", 30)
                .WithColumn("CompanyNo").OfType("char", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Email_List_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Email_List")
                .WithColumn("Email_id").OfType("int", 4)
                .WithColumn("Email").OfType("varchar", 255)
                .WithColumn("Email_First_Name").OfType("varchar", 255).Nullable()
                .WithColumn("Email_Last_Name").OfType("varchar", 255).Nullable()
                .WithColumn("Email_Department_No").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void EmailSpool_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("EmailSpool")
                .WithColumn("EmailSpool_ID").OfType("int", 4)
                .WithColumn("Email_To").OfType("varchar", 1000)
                .WithColumn("Email_CC").OfType("varchar", 1000)
                .WithColumn("Email_Subject").OfType("varchar", 1000).Nullable()
                .WithColumn("Email_Message").OfType("varchar", 5000).Nullable()
                .WithColumn("Attachment_Path").OfType("varchar", 300).Nullable()
                .WithColumn("Created_Dte").OfType("datetime", 8)
                .WithColumn("Completed_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Completed_YN").OfType("Yes_No", 1)
                .WithColumn("EmailSpool_Note").OfType("varchar", 255).Nullable()
                .WithColumn("Email_Status").OfType("int", 4).Nullable()
                .WithColumn("SQLConfirmSuccess").OfType("varchar", 2000)
                .WithColumn("SQLConfirmFailure").OfType("varchar", 2000)
                .WithColumn("HTML_YN").OfType("Yes_No", 1)
                .WithColumn("Email_BCC").OfType("varchar", 1000).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void FormControl_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("FormControl")
                .WithColumn("FormControlList").OfType("Description", 30)
                .WithColumn("FormControlName").OfType("Description", 30)
                .WithColumn("FormNme").OfType("Description", 30)
                .WithColumn("FormControlSequence").OfType("smallint", 2).Nullable()
                .WithColumn("FormControlVisible_YN").OfType("bit", 1);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Image_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Image")
                .WithColumn("ImageName").OfType("varchar", 256)
                .WithColumn("ImageBlob").OfType("image", 16).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void LTS_TimePhase_WF_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("LTS_TimePhase_WF")
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("POTRF_ETA").OfType("datetime", 8)
                .WithColumn("Style1").OfType("varchar", 10)
                .WithColumn("Style2").OfType("varchar", 8)
                .WithColumn("StyleColor").OfType("varchar", 6)
                .WithColumn("Whrse_No").OfType("varchar", 2)
                .WithColumn("LTS_Total").OfType("money", 8)
                .WithColumn("LTS_Qty01").OfType("money", 8)
                .WithColumn("LTS_Qty02").OfType("money", 8)
                .WithColumn("LTS_Qty03").OfType("money", 8)
                .WithColumn("LTS_Qty04").OfType("money", 8)
                .WithColumn("LTS_Qty05").OfType("money", 8)
                .WithColumn("LTS_Qty06").OfType("money", 8)
                .WithColumn("LTS_Qty07").OfType("money", 8)
                .WithColumn("LTS_Qty08").OfType("money", 8)
                .WithColumn("LTS_Qty09").OfType("money", 8)
                .WithColumn("LTS_Qty10").OfType("money", 8)
                .WithColumn("LTS_Qty11").OfType("money", 8)
                .WithColumn("LTS_Qty12").OfType("money", 8)
                .WithColumn("LTS_Qty13").OfType("money", 8)
                .WithColumn("LTS_Qty14").OfType("money", 8)
                .WithColumn("LTS_Qty15").OfType("money", 8)
                .WithColumn("Desc01").OfType("varchar", 6)
                .WithColumn("Desc02").OfType("varchar", 6)
                .WithColumn("Desc03").OfType("varchar", 6)
                .WithColumn("Desc04").OfType("varchar", 6)
                .WithColumn("Desc05").OfType("varchar", 6)
                .WithColumn("Desc06").OfType("varchar", 6)
                .WithColumn("Desc07").OfType("varchar", 6)
                .WithColumn("Desc08").OfType("varchar", 6)
                .WithColumn("Desc09").OfType("varchar", 6)
                .WithColumn("Desc10").OfType("varchar", 6)
                .WithColumn("Desc11").OfType("varchar", 6)
                .WithColumn("Desc12").OfType("varchar", 6)
                .WithColumn("Desc13").OfType("varchar", 6)
                .WithColumn("Desc14").OfType("varchar", 6)
                .WithColumn("Desc15").OfType("varchar", 6);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Pack_Detail_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Pack_Detail")
                .WithColumn("Pack_Id").OfType("varchar", 20)
                .WithColumn("Seq_No").OfType("int", 4)
                .WithColumn("Color_Cd").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Pos").OfType("int", 4).Nullable()
                .WithColumn("Size_Desc").OfType("varchar", 10).Nullable()
                .WithColumn("UPC_No").OfType("varchar", 20).Nullable()
                .WithColumn("QtyPerPack").OfType("int", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void PeopleSoftExport_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("PeopleSoftExport")
                .WithColumn("ID").OfType("int", 4)
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("PoNo").OfType("PO_No", 7)
                .WithColumn("PoStatusCd").OfType("varchar", 2)
                .WithColumn("EntryDte").OfType("datetime", 8)
                .WithColumn("XMLMessage").OfType("text", 16)
                .WithColumn("DestinationInterface").OfType("varchar", 2)
                .WithColumn("LastSentDte").OfType("datetime", 8).Nullable()
                .WithColumn("LastAckStatus").OfType("varchar", 2);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void PeopleSoftExportAck_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("PeopleSoftExportAck")
                .WithColumn("ID").OfType("int", 4)
                .WithColumn("MESSAGE1").OfType("varchar", 500)
                .WithColumn("MESSAGE2").OfType("varchar", 500)
                .WithColumn("MESSAGE3").OfType("varchar", 500)
                .WithColumn("MESSAGE4").OfType("varchar", 500)
                .WithColumn("ENTRYDTE").OfType("datetime", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void PeopleSoftExportControl_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("PeopleSoftExportControl")
                .WithColumn("CompanyNo").OfType("char", 4)
                .WithColumn("LastPOExportDte").OfType("datetime", 8)
                .WithColumn("ErrorFilePath").OfType("varchar", 255)
                .WithColumn("XmlOutputFilePath").OfType("varchar", 255)
                .WithColumn("ListenerURL").OfType("varchar", 255)
                .WithColumn("PSAdminEmail").OfType("varchar", 255)
                .WithColumn("GenErrEmailSubject").OfType("varchar", 100)
                .WithColumn("SendErrEmailSubject").OfType("varchar", 100)
                .WithColumn("RecvErrEmailSubject").OfType("varchar", 100)
                .WithColumn("PSNode").OfType("varchar", 8)
                .WithColumn("PSAckTimeout").OfType("int", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Pick_Printed_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Pick_Printed")
                .WithColumn("SessionID").OfType("int", 4)
                .WithColumn("Picking_No").OfType("varchar", 50);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void PZCRJ514793756_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("PZCRJ514793756")
                .WithColumn("Batch_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Batch_Master_Division_Name").OfType("varchar", 30).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 10).Nullable()
                .WithColumn("Customer_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Batch_no").OfType("varchar", 10).Nullable()
                .WithColumn("Batch_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Batch_Bank_Amt").OfType("float", 8).Nullable()
                .WithColumn("Created_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Status_Cd").OfType("varchar", 5).Nullable()
                .WithColumn("Currencies_cd").OfType("varchar", 3).Nullable()
                .WithColumn("Check_No").OfType("varchar", 25).Nullable()
                .WithColumn("Check_Amt").OfType("float", 8).Nullable()
                .WithColumn("Check_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("GL_Entered_Amt").OfType("float", 8).Nullable()
                .WithColumn("Check_Remark").OfType("varchar", 60).Nullable()
                .WithColumn("Curr_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Curr_Master_Division_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Curr_Discount_Amt").OfType("float", 8).Nullable()
                .WithColumn("Curr_AR_Amount").OfType("float", 8).Nullable()
                .WithColumn("Curr_Cash_Applied_Amt").OfType("float", 8).Nullable()
                .WithColumn("GL_SeqNo").OfType("int", 4).Nullable()
                .WithColumn("Curr_GL_Code").OfType("varchar", 100).Nullable()
                .WithColumn("Curr_GL_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Interco_Master_Division_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Interco_Discount_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_AR_Amount").OfType("float", 8).Nullable()
                .WithColumn("Interco_Cash_Applied_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_GL_Code").OfType("varchar", 100).Nullable()
                .WithColumn("Interco_GL_Amt").OfType("float", 8).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Date").OfType("datetime", 8).Nullable()
                .WithColumn("RECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("GLRECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("ITCORECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("RECID").OfType("int", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void PZCRJWF_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("PZCRJWF")
                .WithColumn("SessionNo").OfType("int", 4).Nullable()
                .WithColumn("Batch_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Batch_Master_Division_Name").OfType("varchar", 30).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 10).Nullable()
                .WithColumn("Customer_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Batch_no").OfType("varchar", 10).Nullable()
                .WithColumn("Batch_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Batch_Bank_Amt").OfType("float", 8).Nullable()
                .WithColumn("Created_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Status_Cd").OfType("varchar", 5).Nullable()
                .WithColumn("Currencies_cd").OfType("varchar", 3).Nullable()
                .WithColumn("Check_No").OfType("varchar", 25).Nullable()
                .WithColumn("Check_Amt").OfType("float", 8).Nullable()
                .WithColumn("Check_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("GL_Entered_Amt").OfType("float", 8).Nullable()
                .WithColumn("Check_Remark").OfType("varchar", 60).Nullable()
                .WithColumn("Curr_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Curr_Master_Division_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Curr_Discount_Amt").OfType("float", 8).Nullable()
                .WithColumn("Curr_AR_Amount").OfType("float", 8).Nullable()
                .WithColumn("Curr_Cash_Applied_Amt").OfType("float", 8).Nullable()
                .WithColumn("GL_SeqNo").OfType("int", 4).Nullable()
                .WithColumn("Curr_GL_Code").OfType("varchar", 100).Nullable()
                .WithColumn("Curr_GL_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_Master_Division_No").OfType("varchar", 4).Nullable()
                .WithColumn("Interco_Master_Division_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Interco_Discount_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_AR_Amount").OfType("float", 8).Nullable()
                .WithColumn("Interco_Cash_Applied_Amt").OfType("float", 8).Nullable()
                .WithColumn("Interco_GL_Code").OfType("varchar", 100).Nullable()
                .WithColumn("Interco_GL_Amt").OfType("float", 8).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Date").OfType("datetime", 8).Nullable()
                .WithColumn("RECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("GLRECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("ITCORECIDHEAD").OfType("int", 4).Nullable()
                .WithColumn("RECID").OfType("int", 4);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void QTask_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("QTask")
                .WithColumn("QTask_ID").OfType("int", 4)
                .WithColumn("QTask_Label").OfType("varchar", 255).Nullable()
                .WithColumn("QTask_Command").OfType("varchar", 1000).Nullable()
                .WithColumn("QTask_Message").OfType("varchar", 5000).Nullable()
                .WithColumn("QTask_Status").OfType("varchar", 2)
                .WithColumn("QTask_Created").OfType("datetime", 8).Nullable()
                .WithColumn("QTask_ProcessStarted").OfType("datetime", 8).Nullable()
                .WithColumn("QTask_ProcessEnded").OfType("datetime", 8).Nullable()
                .WithColumn("QTask_SessionNo").OfType("int", 4).Nullable()
                .WithColumn("QTask_CompanyNo").OfType("varchar", 4).Nullable()
                .WithColumn("QTask_Server").OfType("varchar", 60).Nullable()
                .WithColumn("QTask_Connect").OfType("varchar", 1000).Nullable()
                .WithColumn("QTask_Repeat").OfType("int", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void rBoughtSold_Buf_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("rBoughtSold_Buf")
                .WithColumn("Group1").OfType("varchar", 100)
                .WithColumn("Group2").OfType("varchar", 100)
                .WithColumn("Group3").OfType("varchar", 100)
                .WithColumn("Group4").OfType("varchar", 100)
                .WithColumn("Group5").OfType("varchar", 100).Nullable()
                .WithColumn("Style1").OfType("varchar", 10)
                .WithColumn("Style2").OfType("varchar", 10)
                .WithColumn("StyleColor").OfType("varchar", 10)
                .WithColumn("Whrse_No").OfType("varchar", 10)
                .WithColumn("Currencies_Cd").OfType("varchar", 10)
                .WithColumn("SessionNo").OfType("int", 4).Nullable()
                .WithColumn("Country_Cd").OfType("varchar", 3)
                .WithColumn("PoPrice").OfType("money", 8).Nullable()
                .WithColumn("POD_ID").OfType("int", 4).Nullable()
                .WithColumn("PO_Date").OfType("datetime", 8).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 22).Nullable()
                .WithColumn("Order_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Order_Type_Cd").OfType("varchar", 22).Nullable()
                .WithColumn("Order_Catg_Cd").OfType("varchar", 22).Nullable()
                .WithColumn("IHH_Invoice_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("BoughtQty").OfType("money", 8).Nullable()
                .WithColumn("BookingQty").OfType("money", 8).Nullable()
                .WithColumn("Booking$").OfType("money", 8).Nullable()
                .WithColumn("BookingCount").OfType("int", 4).Nullable()
                .WithColumn("RepeatQty").OfType("money", 8).Nullable()
                .WithColumn("Repeat$").OfType("money", 8).Nullable()
                .WithColumn("RepeatCount").OfType("int", 4).Nullable()
                .WithColumn("ShippedQty").OfType("money", 8).Nullable()
                .WithColumn("Shipped$").OfType("money", 8).Nullable()
                .WithColumn("CancelQty").OfType("money", 8).Nullable()
                .WithColumn("ReturnQty").OfType("money", 8).Nullable()
                .WithColumn("Return$").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz01").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz02").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz03").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz04").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz05").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz06").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz07").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz08").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz09").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz10").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz11").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz12").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz13").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz14").OfType("money", 8).Nullable()
                .WithColumn("Bal_Trcv_Sz15").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty01").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty02").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty03").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty04").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty05").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty06").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty07").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty08").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty09").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty10").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty11").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty12").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty13").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty14").OfType("money", 8).Nullable()
                .WithColumn("ReceivingQty15").OfType("money", 8).Nullable()
                .WithColumn("BookQty01").OfType("money", 8).Nullable()
                .WithColumn("BookQty02").OfType("money", 8).Nullable()
                .WithColumn("BookQty03").OfType("money", 8).Nullable()
                .WithColumn("BookQty04").OfType("money", 8).Nullable()
                .WithColumn("BookQty05").OfType("money", 8).Nullable()
                .WithColumn("BookQty06").OfType("money", 8).Nullable()
                .WithColumn("BookQty07").OfType("money", 8).Nullable()
                .WithColumn("BookQty08").OfType("money", 8).Nullable()
                .WithColumn("BookQty09").OfType("money", 8).Nullable()
                .WithColumn("BookQty10").OfType("money", 8).Nullable()
                .WithColumn("BookQty11").OfType("money", 8).Nullable()
                .WithColumn("BookQty12").OfType("money", 8).Nullable()
                .WithColumn("BookQty13").OfType("money", 8).Nullable()
                .WithColumn("BookQty14").OfType("money", 8).Nullable()
                .WithColumn("BookQty15").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty01").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty02").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty03").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty04").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty05").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty06").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty07").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty08").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty09").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty10").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty11").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty12").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty13").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty14").OfType("money", 8).Nullable()
                .WithColumn("RepeatQty15").OfType("money", 8).Nullable()
                .WithColumn("ShipQty01").OfType("money", 8).Nullable()
                .WithColumn("ShipQty02").OfType("money", 8).Nullable()
                .WithColumn("ShipQty03").OfType("money", 8).Nullable()
                .WithColumn("ShipQty04").OfType("money", 8).Nullable()
                .WithColumn("ShipQty05").OfType("money", 8).Nullable()
                .WithColumn("ShipQty06").OfType("money", 8).Nullable()
                .WithColumn("ShipQty07").OfType("money", 8).Nullable()
                .WithColumn("ShipQty08").OfType("money", 8).Nullable()
                .WithColumn("ShipQty09").OfType("money", 8).Nullable()
                .WithColumn("ShipQty10").OfType("money", 8).Nullable()
                .WithColumn("ShipQty11").OfType("money", 8).Nullable()
                .WithColumn("ShipQty12").OfType("money", 8).Nullable()
                .WithColumn("ShipQty13").OfType("money", 8).Nullable()
                .WithColumn("ShipQty14").OfType("money", 8).Nullable()
                .WithColumn("ShipQty15").OfType("money", 8).Nullable()
                .WithColumn("CanQty1").OfType("money", 8).Nullable()
                .WithColumn("CanQty2").OfType("money", 8).Nullable()
                .WithColumn("CanQty3").OfType("money", 8).Nullable()
                .WithColumn("CanQty4").OfType("money", 8).Nullable()
                .WithColumn("CanQty5").OfType("money", 8).Nullable()
                .WithColumn("CanQty6").OfType("money", 8).Nullable()
                .WithColumn("CanQty7").OfType("money", 8).Nullable()
                .WithColumn("CanQty8").OfType("money", 8).Nullable()
                .WithColumn("CanQty9").OfType("money", 8).Nullable()
                .WithColumn("CanQty10").OfType("money", 8).Nullable()
                .WithColumn("CanQty11").OfType("money", 8).Nullable()
                .WithColumn("CanQty12").OfType("money", 8).Nullable()
                .WithColumn("CanQty13").OfType("money", 8).Nullable()
                .WithColumn("CanQty14").OfType("money", 8).Nullable()
                .WithColumn("CanQty15").OfType("money", 8).Nullable()
                .WithColumn("Qty01").OfType("money", 8).Nullable()
                .WithColumn("Qty02").OfType("money", 8).Nullable()
                .WithColumn("Qty03").OfType("money", 8).Nullable()
                .WithColumn("Qty04").OfType("money", 8).Nullable()
                .WithColumn("Qty05").OfType("money", 8).Nullable()
                .WithColumn("Qty06").OfType("money", 8).Nullable()
                .WithColumn("Qty07").OfType("money", 8).Nullable()
                .WithColumn("Qty08").OfType("money", 8).Nullable()
                .WithColumn("Qty09").OfType("money", 8).Nullable()
                .WithColumn("Qty10").OfType("money", 8).Nullable()
                .WithColumn("Qty11").OfType("money", 8).Nullable()
                .WithColumn("Qty12").OfType("money", 8).Nullable()
                .WithColumn("Qty13").OfType("money", 8).Nullable()
                .WithColumn("Qty14").OfType("money", 8).Nullable()
                .WithColumn("Qty15").OfType("money", 8).Nullable()
                .WithColumn("RetQty01").OfType("money", 8).Nullable()
                .WithColumn("RetQty02").OfType("money", 8).Nullable()
                .WithColumn("RetQty03").OfType("money", 8).Nullable()
                .WithColumn("RetQty04").OfType("money", 8).Nullable()
                .WithColumn("RetQty05").OfType("money", 8).Nullable()
                .WithColumn("RetQty06").OfType("money", 8).Nullable()
                .WithColumn("RetQty07").OfType("money", 8).Nullable()
                .WithColumn("RetQty08").OfType("money", 8).Nullable()
                .WithColumn("RetQty09").OfType("money", 8).Nullable()
                .WithColumn("RetQty10").OfType("money", 8).Nullable()
                .WithColumn("RetQty11").OfType("money", 8).Nullable()
                .WithColumn("RetQty12").OfType("money", 8).Nullable()
                .WithColumn("RetQty13").OfType("money", 8).Nullable()
                .WithColumn("RetQty14").OfType("money", 8).Nullable()
                .WithColumn("RetQty15").OfType("money", 8).Nullable()
                .WithColumn("Theme_Cd").OfType("varchar", 10).Nullable()
                .WithColumn("Theme_Description").OfType("varchar", 30).Nullable()
                .WithColumn("Style_Color_Desc").OfType("varchar", 30)
                .WithColumn("Style_Estimated_Cost").OfType("float", 8).Nullable()
                .WithColumn("Style_Estimated_Cost_num").OfType("float", 8).Nullable()
                .WithColumn("Class_Cd").OfType("varchar", 255)
                .WithColumn("Attribute_Code").OfType("varchar", 10).Nullable()
                .WithColumn("WholesalePrice").OfType("float", 8).Nullable()
                .WithColumn("WholesalePrice_num").OfType("float", 8).Nullable()
                .WithColumn("FirstCost_YN").OfType("bit", 1)
                .WithColumn("Size_Desc01").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc02").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc03").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc04").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc05").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc06").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc07").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc08").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc09").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc10").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc11").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc12").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc13").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc14").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc15").OfType("varchar", 6).Nullable()
                .WithColumn("Division").OfType("varchar", 255).Nullable()
                .WithColumn("Currencies").OfType("varchar", 255)
                .WithColumn("Warehouse").OfType("varchar", 255)
                .WithColumn("Season").OfType("varchar", 255).Nullable()
                .WithColumn("Class").OfType("varchar", 255)
                .WithColumn("GarmentType").OfType("varchar", 255)
                .WithColumn("ProductCategory").OfType("varchar", 255)
                .WithColumn("TypeProduct").OfType("varchar", 255)
                .WithColumn("ThemeCd").OfType("varchar", 255).Nullable()
                .WithColumn("Style").OfType("varchar", 255)
                .WithColumn("Brand").OfType("varchar", 255).Nullable()
                .WithColumn("DeliveryGroup").OfType("varchar", 255).Nullable()
                .WithColumn("Fabric1").OfType("varchar", 255).Nullable()
                .WithColumn("Gender").OfType("varchar", 255)
                .WithColumn("CompanyName").OfType("varchar", 30)
                .WithColumn("Date").OfType("varchar", 11)
                .WithColumn("DivisionG").OfType("varchar", 255).Nullable()
                .WithColumn("CurrenciesG").OfType("varchar", 255)
                .WithColumn("WarehouseG").OfType("varchar", 255)
                .WithColumn("SeasonG").OfType("varchar", 255).Nullable()
                .WithColumn("ClassG").OfType("varchar", 255)
                .WithColumn("GarmentTypeG").OfType("varchar", 255)
                .WithColumn("ProductCategoryG").OfType("varchar", 255)
                .WithColumn("TypeProductG").OfType("varchar", 255)
                .WithColumn("ThemeCdG").OfType("varchar", 255).Nullable()
                .WithColumn("Style1G").OfType("varchar", 255)
                .WithColumn("BrandG").OfType("varchar", 255).Nullable()
                .WithColumn("DeliveryGroupG").OfType("varchar", 255).Nullable()
                .WithColumn("Fabric1G").OfType("varchar", 255).Nullable()
                .WithColumn("GenderG").OfType("varchar", 255)
                .WithColumn("Order_No").OfType("varchar", 50).Nullable()
                .WithColumn("OrderLine_No").OfType("varchar", 50).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void rCutandSoldFG_Data_Buf_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("rCutandSoldFG_Data_Buf")
                .WithColumn("SessionId").OfType("int", 4)
                .WithColumn("Style1").OfType("varchar", 10)
                .WithColumn("Style2").OfType("varchar", 8)
                .WithColumn("StyleColor").OfType("varchar", 6);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void ReportSpool_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("ReportSpool")
                .WithColumn("Job_No").OfType("int", 4)
                .WithColumn("Job_Cd").OfType("varchar", 4)
                .WithColumn("Job_Desc").OfType("varchar", 255)
                .WithColumn("Grouping_No").OfType("int", 4)
                .WithColumn("Users_No").OfType("char", 3).Nullable()
                .WithColumn("JobCreated").OfType("datetime", 8)
                .WithColumn("Report_Name").OfType("varchar", 255).Nullable()
                .WithColumn("Connect").OfType("varchar", 255).Nullable()
                .WithColumn("CompanyNo").OfType("char", 4).Nullable()
                .WithColumn("SessionNo").OfType("int", 4).Nullable()
                .WithColumn("Printer_Name").OfType("varchar", 200).Nullable()
                .WithColumn("JobStarted").OfType("datetime", 8).Nullable()
                .WithColumn("JobEnded").OfType("datetime", 8).Nullable()
                .WithColumn("JobType").OfType("varchar", 10).Nullable()
                .WithColumn("KeepActive").OfType("int", 4)
                .WithColumn("Scheduler_id").OfType("int", 4).Nullable()
                .WithColumn("FolderToSave").OfType("varchar", 300).Nullable()
                .WithColumn("Zip_YN").OfType("Yes_No", 1).Nullable()
                .WithColumn("Group_Email_No").OfType("int", 4).Nullable()
                .WithColumn("Report_FileName").OfType("varchar", 300).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void ReportSpoolEmail_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("ReportSpoolEmail")
                .WithColumn("ReportSpoolEmail_id").OfType("int", 4)
                .WithColumn("Job_No").OfType("int", 4)
                .WithColumn("ReportSpoolEmail_Desc").OfType("varchar", 5000).Nullable()
                .WithColumn("Email_First_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Email_Last_Name").OfType("varchar", 60).Nullable()
                .WithColumn("Email_CC").OfType("varchar", 1000)
                .WithColumn("Email_Subject").OfType("varchar", 255)
                .WithColumn("Email_Message").OfType("varchar", 5000)
                .WithColumn("SQLConfirmSuccess").OfType("varchar", 2000)
                .WithColumn("SQLConfirmFailure").OfType("varchar", 2000);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void ReportSpoolParam_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("ReportSpoolParam")
                .WithColumn("Job_No").OfType("int", 4)
                .WithColumn("Param_No").OfType("int", 4)
                .WithColumn("Param_Value").OfType("varchar", 255).Nullable()
                .WithColumn("Param_Type").OfType("varchar", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void ReportSpoolSpParam_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("ReportSpoolSpParam")
                .WithColumn("Job_No").OfType("int", 4)
                .WithColumn("SpParam_No").OfType("int", 4)
                .WithColumn("SpParam_Value").OfType("varchar", 255).Nullable()
                .WithColumn("SpParam_Type").OfType("varchar", 4).Nullable()
                .WithColumn("SpParamName").OfType("varchar", 60).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void rWFMonthlyOpenPOostSummaryCurr_Buf_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("rWFMonthlyOpenPOostSummaryCurr_Buf")
                .WithColumn("Group1").OfType("varchar", 255).Nullable()
                .WithColumn("Group2").OfType("varchar", 255).Nullable()
                .WithColumn("Group3").OfType("varchar", 255).Nullable()
                .WithColumn("Group4").OfType("varchar", 255).Nullable()
                .WithColumn("Group5").OfType("varchar", 255)
                .WithColumn("Date1").OfType("datetime", 8).Nullable()
                .WithColumn("Date2").OfType("datetime", 8).Nullable()
                .WithColumn("Date3").OfType("datetime", 8).Nullable()
                .WithColumn("Date4").OfType("datetime", 8).Nullable()
                .WithColumn("Date5").OfType("datetime", 8).Nullable()
                .WithColumn("Date6").OfType("datetime", 8).Nullable()
                .WithColumn("Date7").OfType("datetime", 8).Nullable()
                .WithColumn("Date8").OfType("datetime", 8).Nullable()
                .WithColumn("Date9").OfType("datetime", 8).Nullable()
                .WithColumn("Date10").OfType("datetime", 8).Nullable()
                .WithColumn("Date11").OfType("datetime", 8).Nullable()
                .WithColumn("Date12").OfType("datetime", 8).Nullable()
                .WithColumn("Amount_01").OfType("money", 8)
                .WithColumn("Amount_02").OfType("money", 8)
                .WithColumn("Amount_03").OfType("money", 8)
                .WithColumn("Amount_04").OfType("money", 8)
                .WithColumn("Amount_05").OfType("money", 8)
                .WithColumn("Amount_06").OfType("money", 8)
                .WithColumn("Amount_07").OfType("money", 8)
                .WithColumn("Amount_08").OfType("money", 8)
                .WithColumn("Amount_09").OfType("money", 8)
                .WithColumn("Amount_10").OfType("money", 8)
                .WithColumn("Amount_11").OfType("money", 8)
                .WithColumn("Amount_12").OfType("money", 8)
                .WithColumn("Amount_Tot").OfType("money", 8)
                .WithColumn("Label").OfType("varchar", 9).Nullable()
                .WithColumn("Style1").OfType("varchar", 10)
                .WithColumn("Style2").OfType("varchar", 8)
                .WithColumn("StyleColor").OfType("varchar", 6)
                .WithColumn("Currencies_cd").OfType("varchar", 3)
                .WithColumn("Vendor").OfType("varchar", 78)
                .WithColumn("Season").OfType("varchar", 46)
                .WithColumn("Style").OfType("varchar", 20)
                .WithColumn("Division").OfType("varchar", 255)
                .WithColumn("Class").OfType("varchar", 255)
                .WithColumn("GarmentType").OfType("varchar", 255)
                .WithColumn("ProductCategory").OfType("varchar", 255)
                .WithColumn("TypeofProduct").OfType("varchar", 255)
                .WithColumn("StyleTheme").OfType("varchar", 255)
                .WithColumn("DeliveryGroup").OfType("varchar", 255)
                .WithColumn("Brand").OfType("varchar", 255)
                .WithColumn("OrderBy").OfType("text", 16).Nullable()
                .WithColumn("diff").OfType("int", 4).Nullable()
                .WithColumn("PrintSubTotals").OfType("int", 4).Nullable()
                .WithColumn("PrintFob").OfType("int", 4).Nullable()
                .WithColumn("PrintLanded").OfType("int", 4).Nullable()
                .WithColumn("PrintReceived").OfType("int", 4).Nullable()
                .WithColumn("PrintShipped").OfType("int", 4).Nullable()
                .WithColumn("PrintOpen").OfType("int", 4).Nullable()
                .WithColumn("PrintAvailible").OfType("int", 4).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 30)
                .WithColumn("Date").OfType("varchar", 11)
                .WithColumn("SessionId").OfType("int", 4).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Scheduler_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Scheduler")
                .WithColumn("Scheduler_id").OfType("int", 4)
                .WithColumn("Scheduler_cd").OfType("varchar", 4)
                .WithColumn("Scheduler_desc").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void StyleAddInfoFINAL_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("StyleAddInfoFINAL")
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 10).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 10).Nullable()
                .WithColumn("StyleAddInfo").OfType("varchar", 7500).Nullable()
                .WithColumn("Foundation").OfType("varchar", 100).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void TasksToExecute_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("TasksToExecute")
                .WithColumn("Task_ID").OfType("int", 4)
                .WithColumn("TaskType").OfType("varchar", 10)
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("ExecCommand").OfType("varchar", 8000)
                .WithColumn("ExecStatus").OfType("varchar", 2)
                .WithColumn("TimeIntervalInMin").OfType("int", 4)
                .WithColumn("NextRunTime").OfType("datetime", 8).Nullable()
                .WithColumn("CreatedTime").OfType("datetime", 8)
                .WithColumn("StartTime").OfType("datetime", 8)
                .WithColumn("EndTime").OfType("datetime", 8)
                .WithColumn("Duration").OfType("decimal", 9);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void TasksToExecute_Kim_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("TasksToExecute_Kim")
                .WithColumn("Task_ID").OfType("int", 4)
                .WithColumn("TaskType").OfType("varchar", 10)
                .WithColumn("SessionNo").OfType("int", 4)
                .WithColumn("ExecStatus").OfType("varchar", 2)
                .WithColumn("TimeIntervalInMin").OfType("int", 4)
                .WithColumn("NextRunTime").OfType("datetime", 8).Nullable()
                .WithColumn("ExecCommand").OfType("varchar", 8000)
                .WithColumn("CreatedTime").OfType("datetime", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable()
                .WithColumn("Whrse_No").OfType("varchar", 2).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1016167046_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1016167046")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1079246880_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1079246880")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable()
                .WithColumn("Whrse_No").OfType("varchar", 2).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1354210259_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1354210259")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1362450005_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1362450005")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1638389946_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1638389946")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1647453667_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1647453667")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_1842827202_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_1842827202")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_909263970_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_909263970")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_91_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_91")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_Report_WF_940636040_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_Report_WF_940636040")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Qty_Recv").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Whrse_No").OfType("varchar", 2).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1016167046_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1016167046")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1079246880_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1079246880")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Whrse_No").OfType("varchar", 2).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1354210259_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1354210259")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1362450005_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1362450005")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1638389946_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1638389946")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1647453667_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1647453667")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_1842827202_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_1842827202")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable()
                .WithColumn("Commercial_Invoice_No").OfType("varchar", 7).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_909263970_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_909263970")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_91_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_91")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("HTS_No").OfType("varchar", 30).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable()
                .WithColumn("Invoice_No").OfType("varchar", 7).Nullable()
                .WithColumn("InvHlineNo").OfType("int", 4).Nullable()
                .WithColumn("IHH_Invoice_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 6).Nullable()
                .WithColumn("UnitFOBForDuty").OfType("money", 8).Nullable()
                .WithColumn("Duty_Rate").OfType("money", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmp9801_ReportDetail_WF_940636040_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmp9801_ReportDetail_WF_940636040")
                .WithColumn("ShipmentNo").OfType("varchar", 18).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Source").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_No").OfType("varchar", 30).Nullable()
                .WithColumn("Release_Entry_Dte").OfType("datetime", 8).Nullable()
                .WithColumn("Trx_Type").OfType("varchar", 2).Nullable()
                .WithColumn("Quantity").OfType("money", 8).Nullable()
                .WithColumn("Reference").OfType("varchar", 30).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmpBookingSummary_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmpBookingSummary")
                .WithColumn("SessionID").OfType("int", 4).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 60).Nullable()
                .WithColumn("Date").OfType("datetime", 8).Nullable()
                .WithColumn("Season_No").OfType("varchar", 4).Nullable()
                .WithColumn("Country_Cd").OfType("varchar", 3).Nullable()
                .WithColumn("Division_No").OfType("varchar", 2).Nullable()
                .WithColumn("Salesman_cd").OfType("varchar", 2).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 6).Nullable()
                .WithColumn("Theme_Cd").OfType("varchar", 10).Nullable()
                .WithColumn("QtyTotal_S").OfType("money", 8).Nullable()
                .WithColumn("QtyTotal_S2").OfType("money", 8).Nullable()
                .WithColumn("QtyTotal_STD2").OfType("money", 8).Nullable()
                .WithColumn("DollTot_S").OfType("money", 8).Nullable()
                .WithColumn("DollTot_S2").OfType("money", 8).Nullable()
                .WithColumn("DollTot_STD2").OfType("money", 8).Nullable()
                .WithColumn("Forecast_Amount").OfType("money", 8).Nullable()
                .WithColumn("gSeason").OfType("varchar", 255).Nullable()
                .WithColumn("gCountry").OfType("varchar", 255).Nullable()
                .WithColumn("gSalesman").OfType("varchar", 255).Nullable()
                .WithColumn("gDivision").OfType("varchar", 255).Nullable()
                .WithColumn("gCustomer").OfType("varchar", 255).Nullable()
                .WithColumn("gTheme").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmpCuttingTicket_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmpCuttingTicket")
                .WithColumn("Cutting_No").OfType("varchar", 7).Nullable()
                .WithColumn("Cutting_LineNo").OfType("int", 4).Nullable()
                .WithColumn("Season_No").OfType("varchar", 4).Nullable()
                .WithColumn("Season_Name").OfType("varchar", 39).Nullable()
                .WithColumn("Cut_Header_Notes").OfType("varchar", 255).Nullable()
                .WithColumn("Cut_Detail_Notes").OfType("varchar", 255).Nullable()
                .WithColumn("Style1").OfType("varchar", 10).Nullable()
                .WithColumn("Style2").OfType("varchar", 8).Nullable()
                .WithColumn("StyleColor").OfType("varchar", 6).Nullable()
                .WithColumn("Description").OfType("varchar", 120).Nullable()
                .WithColumn("Style_Color_Desc").OfType("varchar", 30).Nullable()
                .WithColumn("Vendor__Style_No").OfType("varchar", 60).Nullable()
                .WithColumn("Patterns").OfType("varchar", 4).Nullable()
                .WithColumn("Bal_Recv_Qty01").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty02").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty03").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty04").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty05").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty06").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty07").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty08").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty09").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty10").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty11").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty12").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty13").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty14").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_Qty15").OfType("money", 8).Nullable()
                .WithColumn("Bal_Recv_QtyTotal").OfType("money", 8).Nullable()
                .WithColumn("Size_Desc01").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc02").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc03").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc04").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc05").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc06").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc07").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc08").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc09").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc10").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc11").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc12").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc13").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc14").OfType("varchar", 6).Nullable()
                .WithColumn("Size_Desc15").OfType("varchar", 6).Nullable()
                .WithColumn("PRO_Part_No").OfType("varchar", 4).Nullable()
                .WithColumn("Description2").OfType("varchar", 120).Nullable()
                .WithColumn("Cutting_Actual_Qty01").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty02").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty03").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty04").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty05").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty06").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty07").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty08").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty09").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty10").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty11").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty12").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty13").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty14").OfType("real", 4).Nullable()
                .WithColumn("Cutting_Actual_Qty15").OfType("real", 4).Nullable()
                .WithColumn("Operation").OfType("int", 4).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 30).Nullable()
                .WithColumn("Date").OfType("datetime", 8).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmpCuttingTicketPic_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmpCuttingTicketPic")
                .WithColumn("Style_Picture1").OfType("varchar", 300).Nullable()
                .WithColumn("Picture_Name").OfType("varchar", 255)
                .WithColumn("Picture_Blob").OfType("image", 16).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmpManagementBookingSummary_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmpManagementBookingSummary")
                .WithColumn("SessionID").OfType("int", 4).Nullable()
                .WithColumn("CompanyName").OfType("varchar", 60).Nullable()
                .WithColumn("Date").OfType("datetime", 8).Nullable()
                .WithColumn("Season_No").OfType("varchar", 4).Nullable()
                .WithColumn("Country_Cd").OfType("varchar", 3).Nullable()
                .WithColumn("Division_No").OfType("varchar", 2).Nullable()
                .WithColumn("Salesman_cd").OfType("varchar", 2).Nullable()
                .WithColumn("Customer_No").OfType("varchar", 6).Nullable()
                .WithColumn("Theme_Cd").OfType("varchar", 10).Nullable()
                .WithColumn("QtyTotal_S").OfType("money", 8).Nullable()
                .WithColumn("QtyTotal_S2").OfType("money", 8).Nullable()
                .WithColumn("QtyTotal_STD2").OfType("money", 8).Nullable()
                .WithColumn("DollTot_S").OfType("money", 8).Nullable()
                .WithColumn("DollTot_S2").OfType("money", 8).Nullable()
                .WithColumn("DollTot_STD2").OfType("money", 8).Nullable()
                .WithColumn("Forecast_Amount").OfType("money", 8).Nullable()
                .WithColumn("gSeason").OfType("varchar", 255).Nullable()
                .WithColumn("gCountry").OfType("varchar", 255).Nullable()
                .WithColumn("gSalesman").OfType("varchar", 255).Nullable()
                .WithColumn("gDivision").OfType("varchar", 255).Nullable()
                .WithColumn("gCustomer").OfType("varchar", 255).Nullable()
                .WithColumn("gTheme").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void tmpProcList_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("tmpProcList")
                .WithColumn("StoredProc_Name").OfType("char", 100);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void Version_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("Version")
                .WithColumn("Version_Name").OfType("varchar", 255)
                .WithColumn("Version_Desc").OfType("varchar", 255)
                .WithColumn("Version_Value").OfType("varchar", 255);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void WIpCopies_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("WIpCopies")
                .WithColumn("CopyTo").OfType("varchar", 255).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void wrkCostSheetMain_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("wrkCostSheetMain")
                .WithColumn("SessionNo").OfType("int", 4).Nullable()
                .WithColumn("Ref_ID").OfType("int", 4).Nullable()
                .WithColumn("ETD").OfType("datetime", 8).Nullable()
                .WithColumn("Style1").OfType("varchar", 10)
                .WithColumn("Style2").OfType("varchar", 8)
                .WithColumn("Description").OfType("varchar", 120).Nullable()
                .WithColumn("Style_ID").OfType("int", 4).Nullable()
                .WithColumn("Style_First_Cost").OfType("LineNum", 4).Nullable()
                .WithColumn("Org_Retail").OfType("LineNum", 4).Nullable()
                .WithColumn("Current_Retail").OfType("LineNum", 4).Nullable()
                .WithColumn("Style_Estimated_Cost").OfType("LineNum", 4)
                .WithColumn("OrigQty").OfType("Y_N", 1).Nullable()
                .WithColumn("Tax_Perc").OfType("SerialNo", 4).Nullable()
                .WithColumn("Allocation_Type").OfType("varchar", 5).Nullable();
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void wrkCostSheetSub_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("wrkCostSheetSub")
                .WithColumn("SessionNo").OfType("int", 4).Nullable()
                .WithColumn("Ref_ID").OfType("int", 4).Nullable()
                .WithColumn("CostCode_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Desc").OfType("varchar", 30)
                .WithColumn("FixPerc").OfType("varchar", 2)
                .WithColumn("To_Country_Cd").OfType("varchar", 3)
                .WithColumn("CostCode_Value").OfType("float", 8).Nullable()
                .WithColumn("CostCode_Amount").OfType("money", 8);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }

        [Test]
        public void zzzStyleRenameTablesForDimConv_is_valid() {
            // Arrange 
            ManualSpecification manual = new ManualSpecification();
            manual.RequireTable("zzzStyleRenameTablesForDimConv")
                .WithColumn("SeqNo").OfType("int", 4)
                .WithColumn("TableName").OfType("varchar", 128)
                .WithColumn("ColName1").OfType("varchar", 128)
                .WithColumn("ColName2").OfType("varchar", 128)
                .WithColumn("ColName3").OfType("varchar", 128);
        
            // Act 
            manual.AssertIsSatisfiedBy(_dbSpecification);
        }


    }
} // namespace
