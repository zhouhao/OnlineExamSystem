###Difference between "TaoBaoExam"    
1. OnlineExamSystem creates exam name first, then add questions to each exam， which means one questions just belongs to one exam, and one exam can have many questions.     
2. TaoBaoExam creates questions first. When an exam is set up, the teacher has two ways to select questions from database into exam, which means one question can belongs to many exams, and one exam can have many questions.     


###This peoject is written by ASP.NET 2.0, and uses Ajax.        
As ASP.NET 2.0 doesn't support Ajax default, you should download "ASPAJAXExtSetup.msi" first, and install it.     
DOWNLOAD: http://www.microsoft.com/en-us/download/details.aspx?id=883     
YOU can find more infomation about it here:http://asp.net/ajax/documentation/live/InstallingASPNETAJAX.aspx    

To run it well, you must config the SQL Server connection. I choose SQL Server 2005, and the database file is in the directory `App_Data`.     
Open `Web.config`, modify the following parameters.    

	<connectionStrings>
		<add name="ConnectionString" connectionString="Data Source=XXXX;Initial Catalog=Examination;User ID=XXXX;Password=XXXX" providerName="System.Data.SqlClient" />
	</connectionStrings>

If you have any question, feel free to contact zhouhaonevershy@gmail.com   
