using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
///  Excell文档转换器
/// |----------------|
/// |Made By Maousama|
/// |----------------|
///  mmmmmh
/// </summary>
namespace ExcellReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        #region BtnSelectFile_Click 选择文件按钮Click事件
        /// <summary>
        /// 选择文件按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TBSelectedFilePath.Text = "";
                foreach (string strName in this.openFileDialog.FileNames)
                {
                    this.TBSelectedFilePath.Text += strName + "\r\n";
                }
            }
        }
        #endregion



        #region BtnCreateDataFile_Click 创建数据文件按钮Click事件
        /// <summary>
        /// 创建数据文件按钮Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateDataFile_Click(object sender, EventArgs e)
        {
            string[] arr = this.TBSelectedFilePath.Text.Trim().Split('\r', '\n');
            if (arr.Length > 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    ReadData(arr[i]);
                }
            }
        }
        #endregion



        #region BtnShowData_Click 选择显示数据按钮Click方法
        /// <summary>
        /// 选择显示数据按钮Click方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowData_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TBShowData.Text = "";
                string strPath = this.openFileDialog.FileName;

                using (GameDataTableParser parse = new GameDataTableParser(strPath))
                {
                    while (!parse.Eof)
                    {
                        StringBuilder sbr = new StringBuilder();
                        for (int i = 0; i < parse.FieldName.Length; i++)
                        {
                            sbr.AppendFormat("{0} ", parse.GetFieldValue(parse.FieldName[i]));
                        }
                        this.TBShowData.Text += sbr.ToString() + "\r\n";
                        parse.Next();
                    }
                }
            }
        }
        #endregion



        #region BtnSelectXorScaleFile_Click 选择Xor按钮的Onclick方法
        /// <summary>
        /// 选择Xor按钮的Onclick方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectXorScaleFile_Click(object sender, EventArgs e)
        {
            if (this.openXorFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TBShowXorFilePath.Text = "";
                foreach (string strName in this.openXorFileDialog.FileNames)
                {
                    this.TBShowXorFilePath.Text += strName + "\r\n";
                }
            }
        }
        #endregion



        #region BtnShowXorScale_Click 显示Xor按钮的方法
        /// <summary>
        /// 显示Xor按钮的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowXorScale_Click(object sender, EventArgs e)
        {
            
            string path = "";
            string[] arr = this.TBShowXorFilePath.Text.Trim().Split('\r', '\n');
            for(int i = 0; i < arr.Length; i++)
            {
                path += arr[i];
            }
            TBShowXorScaleMessage.Text = TxtFileToString(path);
        }
        #endregion



        #region TxtFileToString 将Txt文档的xor码转化成string,同时赋值给XorScaleMgr的xorscale对象
        /// <summary>
        /// 将Txt文档的xor码转化成string,同时赋值给XorScaleMgr的xorscale对象
        /// </summary>
        /// <param name="path">Txt文档路径</param>
        /// <returns></returns>
        private string TxtFileToString(string path)
        {
            string data = "";
            try
            {
                string line;
                // 创建一个 StreamReader 的实例来读取文件 ,using 语句也能关闭 StreamReader
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                {
                    // 从文件读取并显示行，直到文件的末尾
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        data = line;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("The file could not be read:" + e.Message);
            }

            try
            {
                string[] dataArray = data.Split(' ');
                XorScaleMgr.SetXorScaleLength(dataArray.Length);
                for (int i = 0; i < dataArray.Length; i++)
                {
                    //Convert.ToInt32(dataArray[i]);
                    XorScaleMgr.SetXorScaleValue(dataArray[i], i);
                    
                }
            }
            catch(Exception e)
            {
                data = "";
                MessageBox.Show("Please Inport Correct File", e.Message);
            }
            return data;
        }
        #endregion



        #region ReadData 通过路径读取数据
        /// <summary>
        /// 通过路径读取数据
        /// </summary>
        /// <param name="path">数据路径</param>
        private void ReadData(string path)
        {
            
            if (string.IsNullOrEmpty(path)) return;

            string tableName = GetFirstSheetNameByExcelFileName(path, 1);

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
            
            DataTable dt = null;

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception)
                {
                    string strConn2 = "Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source =" + path + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1'";
                    MessageBox.Show(strConn2);
                    OleDbConnection conn2 = new OleDbConnection(strConn);
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("StrConn Error");
                    }
                }
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataSet ds = null;
                strExcel = string.Format("select * from [{0}$]", tableName);
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
                dt = ds.Tables[0];
                myCommand.Dispose();
            }

            CreateData(path, dt);
        }
        #endregion




        #region CreateEntity 创建实体
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="dataArr">数据信息</param>
        private void CreateEntity(string filePath, string fileName, string[,] dataArr)
        {
            StringBuilder sB = new StringBuilder();
            if (dataArr == null) return;
            if (!Directory.Exists(string.Format("{0}Create", filePath)))
            {
                Directory.CreateDirectory(string.Format("{0}Create", filePath));
            }
            using (FileStream fS = new FileStream(string.Format("{0}Create/{1}Entity.cs", filePath, fileName), FileMode.Create))
            {
                sB.Append("\r\n");
                sB.Append("/// <summary>\r\n");
                sB.AppendFormat("/// {0}实体\r\n", fileName);
                sB.Append("/// </summary>\r\n");
                sB.AppendFormat("public partial class {0}Entity : EntityBase\r\n", fileName);
                sB.Append("{\r\n");
                for (int i = 0; i < dataArr.GetLength(0); i++)
                {
                    if (i == 0) { continue; }
                    sB.Append("/// <summary>\r\n");
                    sB.AppendFormat("/// {0}\r\n", dataArr[i, 2]);
                    sB.Append("/// </summary>\r\n");
                    sB.AppendFormat("public {0} {1};\r\n", dataArr[i, 1], dataArr[i, 0]);
                    sB.Append("\r\n");
                }
                sB.Append("}\r\n");

                using (StreamWriter sW = new StreamWriter(fS))
                {
                    sW.Write(sB.ToString());

                }
            }
            MessageBox.Show("Create Entity CS File Successfully");
        }   
        #endregion

        

        #region CreateDBModel 创建数据管理类
        /// <summary>
        /// 创建数据管理类
        /// <summary>
        /// <param name="dataArr">数据信息</param>
        private void CreateDBModel(string filePath, string fileName, string[,] dataArr)
        {
            if (dataArr == null) return;
            StringBuilder sB = new StringBuilder();
            if (dataArr == null) return;
            if (!Directory.Exists(string.Format("{0}Create", filePath)))
            {
                Directory.CreateDirectory(string.Format("{0}Create", filePath));
            }
            using (FileStream fS = new FileStream(string.Format("{0}Create/{1}DBModel.cs", filePath, fileName), FileMode.Create))
            {
                sB.Append("\r\n");
                sB.Append("using ReadExcel;\r\n");
                sB.Append("/// <summary>\r\n");
                sB.AppendFormat("/// {0}数据管理\r\n", fileName);
                sB.Append("/// </summary>\r\n");
                sB.AppendFormat("public partial class {0}DBModel : DBModelBase<{0}DBModel, {0}Entity>\r\n", fileName);
                sB.Append("{\r\n");
                sB.AppendFormat("protected override string filePath {{ get {{ return \"{0}.data\"; }} }}\r\n", fileName);
                sB.AppendFormat("protected override {0}Entity MakeEntity(GameDataTableParser parse)\r\n", fileName);
                sB.Append("{\r\n");
                sB.AppendFormat("{0}Entity entity = new {0}Entity();\r\n", fileName);
                sB.Append("\r\n");
                for (int i = 0; i < dataArr.GetLength(0); i++)
                {
                    sB.AppendFormat("entity.{0} = parse.GetFieldValue(\"{0}\"){1};\r\n", dataArr[i, 0], ChangeTypeName(dataArr[i, 1]));
                }

                sB.Append("\r\n");
                sB.Append("return entity;\r\n");
                sB.Append("}\r\n");
                sB.Append("}\r\n");


                using (StreamWriter sW = new StreamWriter(fS))
                {
                    sW.Write(sB.ToString());

                }
            }
            MessageBox.Show("Create DBModel CS File Successfully");
        }
        #endregion
        

        private string ChangeTypeName(string type)
        {
            string str = string.Empty;
            switch (type)
            {
                case "int":
                    str = ".ToInt()";
                    break;
                case "float":
                    str = ".ToFloat()";
                    break;
            }
            return str;
        }


        
        #region CreateData 生成加密后的文件
        /// <summary>
        /// 生成加密后的文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dt"></param>
        private void CreateData(string path, DataTable dt)
        {
            //数据格式 行数 列数 二维数组每项的值 这里不做判断 都用string存储
            dataArr = null;
            filePath = path.Substring(0, path.LastIndexOf('\\') + 1);
            string fileFullName = path.Substring(path.LastIndexOf('\\') + 1);
            fileName = fileFullName.Substring(0, fileFullName.LastIndexOf('.'));

            byte[] buffer = null;

            using (Game_MemoryStream ms = new Game_MemoryStream())
            {
                int row = dt.Rows.Count;
                int columns = dt.Columns.Count;

                dataArr = new string[columns, 3];

                ms.WriteIntToStream(row);
                ms.WriteIntToStream(columns);
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i < 3)
                        {
                            dataArr[j, i] = dt.Rows[i][j].ToString().Trim();
                        }
                        ms.WriteUTF8Str(dt.Rows[i][j].ToString().Trim());
                    }
                }
                buffer = ms.ToArray();
            }
            //------------------
            //第1步：xor加密
            //------------------
            int iScaleLen = XorScaleMgr.xorScale.Length;
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ XorScaleMgr.xorScale[i % iScaleLen]);
            }

            //------------------
            //第2步：压缩
            //------------------
            //压缩后的字节流
            buffer = ZlibHelper.CompressBytes(buffer);
            //------------------
            //第3步：写入文件
            //------------------
            FileStream fs = new FileStream(string.Format("{0}{1}", filePath, fileName + ".data"), FileMode.Create);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            MessageBox.Show("Create Data File Successfully");
            
        }
        #endregion





        #region GetFirstSheetNameByExcelFileName 获取表格的第一个数据表名称
        /// <summary>
        /// 获取表格的第一个数据表名称
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="numberSheetID"></param>
        /// <returns></returns>
        public string GetFirstSheetNameByExcelFileName(string filepath, int numberSheetID)
        {
            if (!System.IO.File.Exists(filepath))
            {
                return null;
            }
            if (numberSheetID <= 1) { numberSheetID = 1; }
            try
            {
                Excel.Application obj = default(Excel.Application);
                Excel.Workbook objWB = default(Excel.Workbook);
                string strFirstSheetName = null;
                
                obj = (Excel.Application)Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application", string.Empty);
                objWB = obj.Workbooks.Open(filepath, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                strFirstSheetName = ((Excel.Worksheet)objWB.Worksheets[1]).Name;

                objWB.Close(Type.Missing, Type.Missing, Type.Missing);
                objWB = null;
                obj.Quit();
                obj = null;
                return strFirstSheetName;
            }
            catch
            {
                return null;
            }
        }



        #endregion



       

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        #region CreateEntity&CreateDBModel所使用的变量
        /// <summary>
        /// 文件路径变量
        /// </summary>
        public string filePath = string.Empty;
        /// <summary>
        /// 文件名字
        /// </summary>
        public string fileName = string.Empty;

        string[,] dataArr = null;

        #endregion

        /// <summary>
        /// 创建CS文件（Entity与DBModel文件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateCSFile_Click(object sender, EventArgs e)
        {
            if(!(fileName==string.Empty|| filePath == string.Empty|| dataArr == null))
            {
                CreateEntity(filePath, fileName, dataArr);
                CreateDBModel(filePath, fileName, dataArr);
            }
            else
            {
                MessageBox.Show("Please Create CS File After Create Date File!\n\r请先创建Data文件后再创建CS文件操作");
            }
        }
    }

}
