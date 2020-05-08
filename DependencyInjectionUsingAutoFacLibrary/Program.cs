using Autofac;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionUsingAutoFacLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWorkWithData work = new DoWorkWithData(new MySqlDatabase());
            work = new DoWorkWithData(new OracleDatabase());

            //var builder = new ContainerBuilder();
            //builder.RegisterType<MySqlDatabase>().As<IDataConnector>();
            //builder.RegisterType<OracleDatabase>().As<IDataConnector>();
            //builder.RegisterType<DoWorkWithData>();
            //Console.WriteLine("Starting Operation");

            //IContainer container = builder.Build();
            //var work = container.Resolve<DoWorkWithData>();
            work.callAllMethods();
            work.OutputToExcel(new OtherFormatOutputLinux());

            Console.Read();
        }
    }
    public interface IDataConnector
    {
        DataTable GetDataTable();
        string InsertData();
        string UpdateData();
        string DeleteData();
    }

    public class MySqlDatabase : IDataConnector
    {
        public string DeleteData()
        {
            Console.WriteLine("MySql Data Deleted");
            return "done";
        }
        public DataTable GetDataTable()
        {
            Console.WriteLine("MySql DataTable Obtained");
            DataTable dt = new DataTable();
            return dt;
        }
        public string InsertData()
        {
            Console.WriteLine("MySql Data Inserted");
            return "done";
        }
        public string UpdateData()
        {
            Console.WriteLine("MySql Data Updated");
            return "done";
        }
        public void OutputTotext(IOtherFormatOutput otherFormat)
        {
            IOtherFormatOutput _otherFormat = otherFormat;
            _otherFormat.TextOutput();
        }
        public void OutputToExcel(IOtherFormatOutput otherFormat)
        {
            IOtherFormatOutput _ExcelOutput = otherFormat;
            _ExcelOutput.ExcelOutput();

        }
    }
    public class OracleDatabase : IDataConnector
    {
        public string DeleteData()
        {
            Console.WriteLine("Oracle Data Deleted");
            return "done";
        }
        public DataTable GetDataTable()
        {
            Console.WriteLine("Oracle DataTable Obtained");
            DataTable dt = new DataTable();
            return dt;
        }
        public string InsertData()
        {
            Console.WriteLine("Oracle Data Inserted");
            return "done";
        }
        public string UpdateData()
        {
            Console.WriteLine("Oracle Data Updated");
            return "done";
        }
        public void RawOutput(IOtherFormatOutput otherFormat)
        {
            IOtherFormatOutput _rawOutput = otherFormat;
            _rawOutput.RawOutput();
        }
    }
    public class DoWorkWithData
    {
        private IDataConnector data;
        public DoWorkWithData(IDataConnector _data)
        {
            this.data = _data;
        }
        public void callAllMethods()
        {

            try
            {
                data.DeleteData();
                data.InsertData();
                data.UpdateData();
                data.GetDataTable();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        public void OutputToExcel(IOtherFormatOutput ExcelOutput)
        {
            ExcelOutput.ExcelOutput();
        }
        public void OutputToRaw(IOtherFormatOutput RawOutput)
        {
            RawOutput.RawOutput();
        }
        public void OutputToText(IOtherFormatOutput TextOutput)
        {
            TextOutput.TextOutput();
        }

    }

    public interface IOtherFormatOutput
    {
        string TextOutput();
        string ExcelOutput();
        string RawOutput();
    }
    public class OtherFormatOutputLinux : IOtherFormatOutput
    {
        public string ExcelOutput()
        {
            Console.WriteLine("Linux Outputed to Excel sheet File Location:.. ");
            return "c/:ProgramFiles/Excel2.exl";
        }
        public string RawOutput()
        {
            Console.WriteLine("Linux Outputed to Raw Output");
            return "rawOutputLocation...";
        }
        public string TextOutput()
        {
            Console.WriteLine("Linux Outputed to Text File Location:.. ");
            return "c/:ProgramFiles/Text2.txt";
        }
    }
    public class OtherFormatOutputWindows : IOtherFormatOutput
    {
        public string ExcelOutput()
        {
            Console.WriteLine("Windows Outputed to Excel sheet File Location:.. ");
            return "c/:ProgramFiles/Excel2.exl";
        }

        public string RawOutput()
        {
            Console.WriteLine("Windows Outputed to Raw Output");
            return "rawOutputLocation...";
        }

        public string TextOutput()
        {
            Console.WriteLine("Windows Outputed to Text File Location:.. ");
            return "c/:ProgramFiles/Text2.txt";
        }
    }
    public class OtherFormatOutputMac : IOtherFormatOutput
    {
        public string ExcelOutput()
        {
            Console.WriteLine("Mac Outputed to Excel sheet File Location:.. ");
            return "c/:ProgramFiles/Excel2.exl";
        }

        public string RawOutput()
        {
            Console.WriteLine("Mac Outputed to Raw Output");
            return "rawOutputLocation...";
        }

        public string TextOutput()
        {
            Console.WriteLine("Mac Outputed to Text File Location:.. ");
            return "c/:ProgramFiles/Text2.txt";
        }
    }
    

}


