﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class frm_PlanCycle : Form
    {
        //string[] numHistory = { "000, 002, 016, 019, 025, 026, 028, 029, 031, 032, 033, 035, 040, 041, 042, 048, 058, 061, 065, 074, 075, 079, 085, 089, 090, 094, 098, 100, 101, 103, 104, 106, 107, 112, 114, 121, 122, 129, 133, 134, 136, 139, 140, 148, 149, 150, 152, 159, 160, 165, 167, 171, 177, 178, 179, 181, 183, 184, 187, 191, 194, 197, 198, 199, 201, 202, 209, 210, 215, 218, 219, 223, 224, 225, 231, 232, 233, 235, 237, 244, 245, 247, 251, 252, 253, 258, 260, 266, 268, 270, 272, 276, 277, 278, 284, 286, 287, 288, 290, 291, 293, 294, 295, 297, 299, 300, 306, 318, 319, 321, 322, 326, 329, 331, 332, 335, 340, 343, 347, 348, 356, 359, 365, 374, 375, 378, 380, 391, 392, 393, 399, 400, 412, 414, 417, 418, 423, 427, 428, 429, 430, 432, 435, 438, 446, 448, 454, 455, 462, 464, 466, 467, 476, 479, 481, 482, 483, 487, 489, 491, 492, 493, 494, 495, 497, 504, 505, 507, 508, 510, 514, 515, 517, 518, 523, 528, 530, 536, 538, 539, 542, 543, 544, 547, 548, 549, 552, 554, 556, 560, 562, 564, 565, 566, 568, 569, 572, 575, 578, 579, 580, 583, 587, 589, 595, 599, 604, 613, 614, 621, 623, 624, 629, 631, 633, 634, 638, 641, 644, 645, 646, 647, 648, 649, 650, 652, 653, 661, 663, 666, 668, 671, 675, 677, 679, 680, 682, 686, 687, 688, 696, 704, 706, 707, 708, 712, 715, 717, 718, 722, 724, 725, 726, 727, 728, 733, 734, 738, 739, 742, 744, 750, 751, 755, 756, 758, 759, 762, 763, 766, 768, 772, 773, 774, 780, 782, 789, 791, 793, 801, 802, 803, 805, 807, 810, 817, 818, 820, 823, 824, 826, 829, 830, 831, 835, 837, 838, 841, 842, 844, 846, 847, 848, 850, 855, 857, 858, 859, 861, 865, 867, 876, 878, 881, 883, 887, 888, 891, 892, 893, 894, 899, 903, 904, 907, 912, 916, 917, 922, 924, 925, 928, 930, 934, 938, 939, 940, 946, 949, 953, 958, 960, 965, 967, 968, 976, 978, 979, 980, 983" };
        string[] numHistory;
        public static JArray jArrHistoryNumber;
        string NowAnalyzeNumber = "";
        public static JArray NowAnalyzeNumberArr;

        //五星亂數用不到了
        //private void getFiveNumber()
        //{

        //    System.Reflection.Assembly thisExe;
        //    thisExe = System.Reflection.Assembly.GetExecutingAssembly();
        //    Stream file = thisExe.GetManifestResourceStream("WinFormsApp1.Number.20180501Number.txt");

        //    string text = "";

        //    using (StreamReader sr = new StreamReader(file, Encoding.Default))
        //    {
        //        text = sr.ReadToEnd();
        //        //MessageBox.Show(strTxt); 
        //    }

        //    string[] test = text.Split('"');
        //    string[] test2 = test[0].Split(',');
        //    lblBets.Text = test2.Count().ToString();
        //    numHistory = test;


        //    string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
        //var frmGameMainjArr = jArrHistoryNumber.Where(x => x["Issue"].ToString().Contains(date)).ToList();

        #region 需要排序在打開
        //需要新排序請用這裡
        //string[] test2 = test[0].Split(',');
        //string temp = "";

        //Array.Sort(test2, 0, test2.Count());
        //for (int i = 0; i < test2.Count(); i++)
        //{
        //    temp += ", " + test2[i];
        //}

        //string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
        //using (FileStream fs = File.Create(@"E:\" + date + "Number.txt"))
        //{
        //    Byte[] info = new UTF8Encoding(true).GetBytes(temp.Substring(2));
        //    // Add some information to the file.
        //    fs.Write(info, 0, info.Length);
        //}


        //未來自動產出的方法
        /*
        Random generator = new Random();
        string TodayQuantity = "";
        string NumberFileTmp = "";

        //先決定這次產出的筆數
        switch (cbGamePlus.Text)
        {
            case "30000+":
                TodayQuantity = generator.Next(30000, 39999).ToString();
                break;
            case "40000+":
                TodayQuantity = generator.Next(40000, 49999).ToString();
                break;
            case "50000+":
                TodayQuantity = generator.Next(50000, 59999).ToString();
                break;
        }
        //每期注数 (依計畫而定)
        lblBets.Text = TodayQuantity;

        string tmpString = "";
        int j = Convert.ToInt32(TodayQuantity);

        String r = "";
        var resourceNames = new List<string>();

        for (int i = 0; i < 1; i++) 
        {
            tmpString = "";
            //Random generator = new Random();
            for (int ii = 0; ii < j; ii++)
            {
                r = generator.Next(0, 99999).ToString("D5");
                if (!tmpString.Contains(r))
                {
                    tmpString = tmpString + "," + r ;
                }
                else
                {
                    ii--;
                }
            }
            NumberFileTmp += "\"" + tmpString.Substring(1) ;
            resourceNames.Add(tmpString);
        }

        //排序重組
        string[] NumberFileTmpSort = NumberFileTmp.Substring(1).Split('"');

        string[] TmpArr;
        string tmpSortString = "";
        string[] TmpSortArr;
        var resourceNamesSort = new List<string>();


        for (int i = 0; i < NumberFileTmpSort.Count(); i++)
        {
            TmpSortArr = NumberFileTmpSort[i].Split(',');
            Array.Sort(TmpSortArr, 0, TmpSortArr.Count());
            tmpSortString = "";
            for (int ii = 0; ii < TmpSortArr.Count(); ii++)
            {
                tmpSortString += ", " + TmpSortArr[ii];
            }
            resourceNamesSort.Add("\"" + tmpSortString.Substring(2));
        }

        string fileNumber = "";
        for (int i = 0; i < resourceNamesSort.Count(); i++)
        {
            fileNumber += resourceNamesSort[i];
        }

        string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
        using (FileStream fs = File.Create(@"E:\" + date + "Number.txt"))
        {
            Byte[] info = new UTF8Encoding(true).GetBytes(NumberFileTmp.Substring(1));
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }

        string text = System.IO.File.ReadAllText(@"E:\" + date + "Number.txt");

        string[] test = text.Split('"');
        string[] test2 = test[0].Split(',');
        //FiveNumber = test;*/
        #endregion
        // }

        private class ComboboxItem
        {
            public ComboboxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }
            public string Value
            {
                get;
                set;
            }
            public string Text
            {
                get;
                set;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        public frm_PlanCycle()
        {
            InitializeComponent();
            string NowDate = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", @"/");
            label115.Text = NowDate + "历史开奖";

            txtGameNum.ForeColor = Color.LightGray;
            txtGameNum.Text = "请输入奖金号";
            this.txtGameNum.Leave += new System.EventHandler(this.txtGameNum_Leave);
            this.txtGameNum.Enter += new System.EventHandler(this.txtGameNum_Enter);

            txtTimes.ForeColor = Color.LightGray;
            txtTimes.Text = "请输入倍数";
            this.txtTimes.Leave += new System.EventHandler(this.txtTimes_Leave);
            this.txtTimes.Enter += new System.EventHandler(this.txtTimes_Enter);

            cbMoney.SelectedIndex = 0;
            cbGameKind.SelectedIndex = 0;
            cbGameDirect.SelectedIndex = 0;
            cbGamePlus.SelectedIndex = 0;
            //cbGamePlan.SelectedIndex = 0;
            cbGameCycle.SelectedIndex = 0;

            //先把廣告圖片隱藏起來

        }

        #region TextBox的提示
        private void txtGameNum_Leave(object sender, EventArgs e)
        {
            if (txtGameNum.Text == "")
            {
                txtGameNum.Text = "请输入奖金号";
                txtGameNum.ForeColor = Color.Gray;
            }
        }
        private void txtGameNum_Enter(object sender, EventArgs e)
        {
            if (txtGameNum.Text == "请输入奖金号")
            {
                txtGameNum.Text = "";
                txtGameNum.ForeColor = Color.Black;
            }
        }
        private void txtTimes_Leave(object sender, EventArgs e)
        {
            if (txtTimes.Text == "")
            {
                txtTimes.Text = "请输入倍数";
                txtTimes.ForeColor = Color.Gray;
            }
        }
        private void txtTimes_Enter(object sender, EventArgs e)
        {
            if (txtTimes.Text == "请输入倍数")
            {
                txtTimes.Text = "";
                txtTimes.ForeColor = Color.Black;
            }
        }
        #endregion

        #region ComboBox的切換處理
        private void cbGameKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbGameKind.SelectedItem.ToString())
            {
                case "五星":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("星组合");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("30000+");
                    cbGamePlus.Items.Add("40000+");
                    cbGamePlus.Items.Add("50000+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "四星":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("四星组合");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("3000+");
                    cbGamePlus.Items.Add("4000+");
                    cbGamePlus.Items.Add("5000+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "前三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("组合");
                    cbGameDirect.Items.Add("和值");
                    cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "中三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    //cbGameDirect.Items.Add("中三组合");
                    cbGameDirect.Items.Add("和值");
                    cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "后三":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    //.Items.Add("后三组合");
                    cbGameDirect.Items.Add("和值");
                    cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("300+");
                    cbGamePlus.Items.Add("400+");
                    cbGamePlus.Items.Add("500+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "前二":
                case "后二":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("单式");
                    cbGameDirect.Items.Add("复式");
                    cbGameDirect.Items.Add("和值");
                    cbGameDirect.Items.Add("跨度");
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    cbGamePlus.Items.Add("30+");
                    cbGamePlus.Items.Add("40+");
                    cbGamePlus.Items.Add("50+");
                    cbGamePlus.SelectedIndex = 0;
                    break;
                case "定位胆":
                    cbGameDirect.Items.Clear();
                    cbGameDirect.Items.Add("万");
                    cbGameDirect.Items.Add("千");
                    cbGameDirect.Items.Add("百");
                    cbGameDirect.Items.Add("十");
                    cbGameDirect.Items.Add("个");
                    //todo: 定位胆的處理
                    cbGameDirect.SelectedIndex = 0;
                    cbGamePlus.Items.Clear();
                    break;
                default:
                    break;
            }
        }

        private void cbGamePlus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbGamePlus.SelectedItem.ToString().Substring(0, 1))
            {
                case "3":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("3", "三期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btnViewResult_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtGameNum.Text) < 1700 || Int32.Parse(txtGameNum.Text) > 2000)
            {
                MessageBox.Show("只能输入1700 ~ 2000的数字");
                txtGameNum.Focus();
                return;
            }
            ConnectDbGetHistoryNumber();
            pnlShowPlan.Visible = false;
            if (txtGameNum.Text == "" || txtGameNum.Text == "请输入奖金号" ||
                txtTimes.Text == "" || txtTimes.Text == "请输入倍数" ||
                (ckRegularCycle.Checked == false && ckWinToNextCycle.Checked == false) ||
                cbGamePlus.SelectedItem == null ||
                cbGamePlan.SelectedItem == null)
            {
                MessageBox.Show("所有欄位都必須輸入");
                return;
            }

            CountAndShow();

            #region 先mark
            /*
            
            int cycle_1 = 1; //列出計畫號碼的周期數
            int cycle_2 = 1; //比對開獎的周期數
            int sumBets = 0, LastBets = 0; //總投注數 //最後計算
            int sumWin = 0; //中奖次數
            
            if (cbGameKind.Text == "中三" && cbGamePlus.Text == "300+" && cbGamePlan.Text == "玉神计划" && (cbGameCycle.Text == "三期一周" || cbGameCycle.Text == "二期一周"))
            {
                string threeNumber = "000, 002, 016, 019, 025, 026, 028, 029, 031, 032, 033, 035, 040, 041, 042, 048, 058, 061, 065, 074, 075, 079, 085, 089, 090, 094, 098, 100, 101, 103, 104, 106, 107, 112, 114, 121, 122, 129, 133, 134, 136, 139, 140, 148, 149, 150, 152, 159, 160, 165, 167, 171, 177, 178, 179, 181, 183, 184, 187, 191, 194, 197, 198, 199, 201, 202, 209, 210, 215, 218, 219, 223, 224, 225, 231, 232, 233, 235, 237, 244, 245, 247, 251, 252, 253, 258, 260, 266, 268, 270, 272, 276, 277, 278, 284, 286, 287, 288, 290, 291, 293, 294, 295, 297, 299, 300, 306, 318, 319, 321, 322, 326, 329, 331, 332, 335, 340, 343, 347, 348, 356, 359, 365, 374, 375, 378, 380, 391, 392, 393, 399, 400, 412, 414, 417, 418, 423, 427, 428, 429, 430, 432, 435, 438, 446, 448, 454, 455, 462, 464, 466, 467, 476, 479, 481, 482, 483, 487, 489, 491, 492, 493, 494, 495, 497, 504, 505, 507, 508, 510, 514, 515, 517, 518, 523, 528, 530, 536, 538, 539, 542, 543, 544, 547, 548, 549, 552, 554, 556, 560, 562, 564, 565, 566, 568, 569, 572, 575, 578, 579, 580, 583, 587, 589, 595, 599, 604, 613, 614, 621, 623, 624, 629, 631, 633, 634, 638, 641, 644, 645, 646, 647, 648, 649, 650, 652, 653, 661, 663, 666, 668, 671, 675, 677, 679, 680, 682, 686, 687, 688, 696, 704, 706, 707, 708, 712, 715, 717, 718, 722, 724, 725, 726, 727, 728, 733, 734, 738, 739, 742, 744, 750, 751, 755, 756, 758, 759, 762, 763, 766, 768, 772, 773, 774, 780, 782, 789, 791, 793, 801, 802, 803, 805, 807, 810, 817, 818, 820, 823, 824, 826, 829, 830, 831, 835, 837, 838, 841, 842, 844, 846, 847, 848, 850, 855, 857, 858, 859, 861, 865, 867, 876, 878, 881, 883, 887, 888, 891, 892, 893, 894, 899, 903, 904, 907, 912, 916, 917, 922, 924, 925, 928, 930, 934, 938, 939, 940, 946, 949, 953, 958, 960, 965, 967, 968, 976, 978, 979, 980, 983";
                List<string> numHistoryList = new List<string>();
                numHistoryList.Add(threeNumber);
                numHistory = numHistoryList.ToArray();

                pnlShowPlan.Visible = true;                
                ComboboxItem item = cbGameCycle.Items[cbGameCycle.SelectedIndex] as ComboboxItem;   
                             
                #region 顯示可看的週期
                cbPlanCycleSelect.Items.Clear();
                
                string cycleName = "";
                for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                {
                    cycleName = "第" + cycle_1.ToString("00") + "周期";
                    string cycleDetail = "";
                    for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                    {
                        if (i < 0)
                            break;
                        cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                        if (j != Convert.ToInt16(item.Value) - 1)
                            i--;
                    }
                    cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                    cycle_1++;
                    i++;
                }
                cbPlanCycleSelect.SelectedIndex = 0;
                #endregion

                #region 驗證是否中奖
                Label lbl_1;
                ComboBox cb_1;
                Label lbl_2;
                Label lbl_3;
                flowLayoutPanel1.Controls.Clear();

                bool isWin = false; //中了沒
                int periodtWin = 0; //第幾期中
                string[] temp = { "", "", "" }; //存放combobox的值

                for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                {
                    //reset
                    isWin = false;
                    periodtWin = 0;
                    temp[0] = "";
                    temp[1] = "";
                    temp[2] = "";

                    lbl_1 = new Label();
                    lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                    lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                    lbl_1.Size = new System.Drawing.Size(72, 25);

                    for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                    {
                        if (i < 0) 
                            break;

                        string strMatch = "";
                        switch (cbGameKind.Text)
                        {
                            case "五星":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                break;
                            case "四星":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                break;
                            case "前三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                break;
                            case "中三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                break;
                            case "后三":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                break;
                            case "前二":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                break;
                            case "后二":
                                strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                break;
                        }                        
                        if (isWin == false) //還沒中
                        {
                            if (numHistory[0].IndexOf(strMatch) > -1) //中
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                isWin = true;

                                if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                {
                                    i++;
                                    sumBets++;
                                    periodtWin = j + 1;
                                    break;
                                }
                            }
                            else //挂
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                            }
                            sumBets++;
                            periodtWin = j + 1;
                        }
                        else //前面已中奖
                        {
                            temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                        }
                        i--;
                    }

                    cycle_2++;
                    i++;

                    cb_1 = new ComboBox();
                    for (int k = 0; k < 3; k++)
                    {
                        if (temp[k] != "")
                            cb_1.Items.Add(temp[k]);
                    }
                    cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                    cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                    cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    cb_1.ForeColor = System.Drawing.Color.Black;
                    cb_1.FormattingEnabled = true;
                    cb_1.Margin = new System.Windows.Forms.Padding(0);
                    cb_1.Size = new System.Drawing.Size(128, 26);
                    cb_1.SelectedIndex = 0;
                    cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                    lbl_2 = new Label();
                    lbl_2.Text = periodtWin.ToString();
                    lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                    lbl_2.Size = new System.Drawing.Size(53, 25);
                    lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    lbl_3 = new Label();
                    if (isWin == true)
                    {
                        lbl_3.Text = "中";
                        lbl_3.ForeColor = System.Drawing.Color.Red;
                        sumWin++;
                    }
                    else
                    {
                        lbl_3.Text = "挂";
                        lbl_3.ForeColor = System.Drawing.Color.Black;
                    }
                    lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                    lbl_3.Size = new System.Drawing.Size(60, 25);
                    lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    flowLayoutPanel1.Controls.Add(lbl_1);
                    flowLayoutPanel1.Controls.Add(cb_1);                     
                    flowLayoutPanel1.Controls.Add(lbl_2);
                    flowLayoutPanel1.Controls.Add(lbl_3);

                    LastBets += Convert.ToInt32(lbl_2.Text);                  
                }

                if (ckRegularCycle.Checked == true) //规律周期
                {                  
                    
                    
                }
                else //中奖即进入下一周期
                { 
                
                }
                #endregion

                #region 計算
                //每期注數 共?元
                //TODO
                lblBets.Text = "350";
                lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                //目前下注?周期
                lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                //共下注?期
                lblSumBetsCycle.Text = LastBets.ToString();
                //總投注額?元
                lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                //獎金?元
                lblWinMoney.Text = (Convert.ToDecimal(txtGameNum.Text) * Convert.ToDecimal(txtTimes.Text)).ToString();
                //盈虧?元
                lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                //中奖率
                lblPlanWinOpp.Text = (sumWin * 100 / Convert.ToDecimal(lblCurrentBetsCycle.Text)).ToString(".##");
                #endregion

                rtxtPlanCycle.ReadOnly = true;
            }
            else if (cbGameKind.Text == "五星") //五星開獎
            {
                getFiveNumber();

                if (cbGameDirect.Text == "复式")
                { 
                
                }
                else if (cbGameDirect.Text == "单式")
                {
                    //要改到外層
                    pnlShowPlan.Visible = true;
                    ComboboxItem item = cbGameCycle.Items[cbGameCycle.SelectedIndex] as ComboboxItem;

                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = (Convert.ToDecimal(txtGameNum.Text) * Convert.ToDecimal(txtTimes.Text)).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
                else
                {
                    MessageBox.Show("請選擇『复式』或『单式』");
                }
            }
            else
            {
                MessageBox.Show("測試請先選擇:中三、300+、玉神计划、三期一周或二期一周");
                return;
            }   
            */
            #endregion
        }

        private void cbPlanCycleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem item = cbPlanCycleSelect.Items[cbPlanCycleSelect.SelectedIndex] as ComboboxItem;
            lblPlanCycleSelected.Text = item.Text;
            lblPlanCycleDetail.Text = item.Value;
            //先固定350組
            //這邊是用死的寫法需修正 TODO
            int Index = cbPlanCycleSelect.SelectedIndex;

            rtxtPlanCycle.Text = NowAnalyzeNumberArr[Index]["Number"].ToString();

            //if (cbPlanCycleSelect.SelectedIndex == 0)
            //    rtxtPlanCycle.Text = numHistory[0];
            //else if (cbPlanCycleSelect.SelectedIndex == 1)
            //    rtxtPlanCycle.Text = numHistory[0];
            //else if (cbPlanCycleSelect.SelectedIndex == 2)
            //    rtxtPlanCycle.Text = numHistory[0];
            //else
            //    rtxtPlanCycle.Text = numHistory[0];
        }

        private void cbCycleResult1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            Pen objPen;
            Font objFont;
            float size = 11;
            FontFamily family = new FontFamily(lblBets.Font.Name);

            if (cb.Items[e.Index].ToString().IndexOf("挂") > -1)
                objPen = new Pen(Color.Black);
            else
                objPen = new Pen(Color.Red); ;

            if (e.Index != -1)
            {
                objFont = new Font(family, size);
                e.Graphics.DrawString((string)cb.Items[e.Index], objFont, objPen.Brush, e.Bounds);
            }
        }
        //取得歷史開獎
        private void UpdateHistory()
        {
            string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            if (rtxtHistory.Text == "") //無資料就全寫入
            {
                for (int i = 0; i < frmGameMain.jArr.Count; i++)
                {
                    //if (i == 120) break; //寫120筆就好
                    if (frmGameMain.jArr[i]["Issue"].ToString().Contains(date))
                        rtxtHistory.Text += "第" + frmGameMain.jArr[i]["Issue"].ToString() + "期  " + frmGameMain.jArr[i]["Number"].ToString().Replace(",", " ") + "\r\n";
                }
            }
            else //有資料先判斷
            {
                if ((rtxtHistory.Text.Substring(0, 11) != frmGameMain.jArr[0]["Issue"].ToString()) && (frmGameMain.strHistoryNumberOpen != "?")) //有新資料了
                {
                    rtxtHistory.Text = "";
                    for (int i = 0; i < frmGameMain.jArr.Count; i++)
                    {
                        //if (i == 120) break; //寫120筆就好
                        if (frmGameMain.jArr[i]["Issue"].ToString().Contains(date))
                            rtxtHistory.Text += "第" + frmGameMain.jArr[i]["Issue"].ToString() + "期  " + frmGameMain.jArr[i]["Number"].ToString().Replace(",", " ") + "\r\n";
                    }
                }
            }
        }

        private void picAD1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.zhcw.com/");
        }

        private void picAD2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.cqcp.net/");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 300000;
            UpdateHistory();
        }

        private void txtGameNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只能輸入數字
            if (e.KeyChar != '\b') //後退鍵以外的字元
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')) //0~9
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只能輸入數字
            if (e.KeyChar != '\b') //後退鍵以外的字元
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')) //0~9
                {
                    e.Handled = true;
                }
            }
        }

        private void ckRegularCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRegularCycle.Checked == true)
                ckWinToNextCycle.Checked = false;
        }

        private void ckWinToNextCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (ckWinToNextCycle.Checked == true)
                ckRegularCycle.Checked = false;
        }

        private void btnEditPlanNumber_Click(object sender, EventArgs e)
        {
            rtxtPlanCycle.ReadOnly = false;
        }

        private void btnCopyPlanNumber_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtxtPlanCycle.Text);
            MessageBox.Show("已复制到剪贴簿");
            //Random R = new Random();

            //string[] temp = new string[350];

            //Random rand = new Random(Guid.NewGuid().GetHashCode());

            //List<int> listLinq = new List<int>(Enumerable.Range(0, 999));
            //listLinq = listLinq.OrderBy(num => rand.Next()).ToList<int>();

            //for (int i = 0; i < 350; i++)
            //{
            //    temp[i] = listLinq[i].ToString("000");
            //}
            //Array.Sort(temp);

            //rtxtPlanCycle.Text = "";
            //for (int i = 0; i < 350; i++)
            //{
            //    rtxtPlanCycle.Text += temp[i] + ", ";
            //} 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnFiveNumberGodPlan_Click(object sender, EventArgs e)
        {
            ConnectDbGetHistoryNumber();

            #region 設定選項名稱
            //設定選項名稱
            cbGameKind.Text = "五星";

            cbGameDirect.Items.Clear();
            cbGameDirect.Items.Add("单式");
            cbGameDirect.Items.Add("复式");
            cbGameDirect.SelectedIndex = 0;
            cbGamePlus.Items.Clear();
            cbGamePlus.Items.Add("30000+");
            cbGamePlus.Items.Add("40000+");
            cbGamePlus.Items.Add("50000+");
            cbGamePlus.SelectedIndex = 0;
            cbGamePlus.Text = "30000+";

            cbGamePlan.Text = "玉神计划";

            switch (cbGamePlus.SelectedItem.ToString().Substring(0, 1))
            {
                case "3":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("3", "三期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                default:
                    break;
            }

            #endregion

            CountAndShow();
        }

        private void btnMidthrNumberPhantomPlan_Click(object sender, EventArgs e)
        {
            ConnectDbGetHistoryNumber();

            #region 設定選項名稱
            cbGameKind.Text = "中三";

            cbGameDirect.Items.Clear();
            cbGameDirect.Items.Add("单式");
            cbGameDirect.Items.Add("复式");
            cbGameDirect.Items.Add("和值");
            cbGameDirect.Items.Add("跨度");
            cbGameDirect.SelectedIndex = 0;
            cbGamePlus.Items.Clear();
            cbGamePlus.Items.Add("300+");
            cbGamePlus.Items.Add("400+");
            cbGamePlus.Items.Add("500+");
            cbGamePlus.SelectedIndex = 0;

            cbGamePlan.Text = "幻影计划";//玉神计划幻影计划

            switch (cbGamePlus.SelectedItem.ToString().Substring(0, 1))
            {
                case "3":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("3", "三期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                default:
                    break;
            }

            //這次用兩期一周
            cbGameCycle.SelectedIndex = 1;

            //用進入下一期
            ckWinToNextCycle.Checked = true;

            #endregion

            CountAndShow();

        }

        private void CountAndShow()
        {
            int cycle_1 = 1; //列出計畫號碼的周期數
            int cycle_2 = 1; //比對開獎的周期數
            int sumBets = 0, LastBets = 0; //總投注數 //最後計算
            int sumWin = 0, sumFail = 0; //中奖次數

            //抓取比對的投注數量
            ConnectDbGetRandomNumber(cbGamePlus.Text, cbGamePlan.Text);
            //for (int i = 0; i < NowAnalyzeNumberArr.Count(); i++)
            //{

            //}
            string threeNumber = NowAnalyzeNumber;
            List<string> numHistoryList = new List<string>();
            numHistoryList.Add(threeNumber);
            numHistory = numHistoryList.ToArray();
            lblBets.Text = numHistory[0].Split(',').Count().ToString();

            //要改到外層
            pnlShowPlan.Visible = true;
            ComboboxItem item = cbGameCycle.Items[cbGameCycle.SelectedIndex] as ComboboxItem;

            if (cbGameKind.Text == "中三") //&& (cbGameCycle.Text == "三期一周" || cbGameCycle.Text == "二期一周")
            {

                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {
                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = ((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text)) * 1)).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
            }
            else if (cbGameKind.Text == "五星") //五星開獎
            {
                //ConnectDbGetRandomNumber(cbGamePlus.Text);

                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {


                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = ((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text) * 100) )).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
                else
                {
                    MessageBox.Show("請選擇『复式』或『单式』");
                }
            }
            else if (cbGameKind.Text == "四星")
            {
                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {

                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = ((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text) * 10))).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
                else
                {
                    MessageBox.Show("請選擇『复式』或『单式』");
                }
            }
            else if (cbGameKind.Text == "前三")
            {
                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {

                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = ((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text) * 1))).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
            }
            else if (cbGameKind.Text == "后三")
            {
                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {

                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = ((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text) * 1))).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
            }
            else if (cbGameKind.Text == "前二")
            {
                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {
                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = (Convert.ToDouble((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text)))) *0.1).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
            }
            else if (cbGameKind.Text == "后二")
            {
                if (cbGameDirect.Text == "复式")
                {

                }
                else if (cbGameDirect.Text == "单式")
                {
                    #region 顯示可看的週期
                    cbPlanCycleSelect.Items.Clear();

                    string cycleName = "";
                    for (int i = jArrHistoryNumber.Count - 1; i >= 0; i--)
                    {
                        cycleName = "第" + cycle_1.ToString("00") + "周期";
                        string cycleDetail = "";
                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0)
                                break;
                            cycleDetail += "" + jArrHistoryNumber[i]["Issue"].ToString() + "期 ． ";
                            if (j != Convert.ToInt16(item.Value) - 1)
                                i--;
                        }
                        cbPlanCycleSelect.Items.Add(new ComboboxItem(cycleDetail, cycleName));
                        cycle_1++;
                        //i++;
                    }
                    cbPlanCycleSelect.SelectedIndex = 0;
                    #endregion

                    #region 驗證是否中奖
                    Label lbl_1;
                    ComboBox cb_1;
                    Label lbl_2;
                    Label lbl_3;
                    flowLayoutPanel1.Controls.Clear();

                    bool isWin = false; //中了沒
                    int periodtWin = 0; //第幾期中
                    string[] temp = { "", "", "" }; //存放combobox的值

                    for (int i = jArrHistoryNumber.Count() - 1; i >= 0; i--) //從歷史結果開始比
                    {
                        //reset
                        isWin = false;
                        periodtWin = 0;
                        temp[0] = "";
                        temp[1] = "";
                        temp[2] = "";

                        lbl_1 = new Label();
                        lbl_1.Text = "第" + cycle_2.ToString("00") + "周期";
                        lbl_1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
                        lbl_1.Size = new System.Drawing.Size(72, 25);

                        int NumberArrCount = numHistory.Count();

                        for (int j = 0; j < Convert.ToInt16(item.Value); j++)
                        {
                            if (i < 0) break;

                            string strMatch = "";
                            switch (cbGameKind.Text)
                            {
                                case "五星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "");
                                    break;
                                case "四星":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 4);
                                    break;
                                case "前三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 3);
                                    break;
                                case "中三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(1, 3);
                                    break;
                                case "后三":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(2, 3);
                                    break;
                                case "前二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(0, 2);
                                    break;
                                case "后二":
                                    strMatch = jArrHistoryNumber[i]["Number"].ToString().Replace(",", "").Substring(3, 2);
                                    break;
                            }
                            if (isWin == false) //還沒中
                            {
                                ///////////////cycle_2 - 1
                                if (numHistory[0].IndexOf(strMatch) > -1) //中
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 中";
                                    isWin = true;

                                    if (ckWinToNextCycle.Checked == true) //中奖即进入下一周期                                    
                                    {
                                        i--;
                                        sumBets++;
                                        periodtWin = j + 1;
                                        break;
                                    }
                                }
                                else //挂
                                {
                                    temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 挂";
                                }
                                sumBets++;
                                periodtWin = j + 1;
                            }
                            else //前面已中奖
                            {
                                temp[j] = "  " + jArrHistoryNumber[i]["Number"].ToString().Replace(",", " ") + " 停";
                                //cycle_2++;
                            }
                            i--;
                        }

                        cycle_2++;
                        i++;

                        cb_1 = new ComboBox();
                        for (int k = 0; k < 3; k++)
                        {
                            if (temp[k] != "")
                                cb_1.Items.Add(temp[k]);
                        }
                        cb_1.Cursor = System.Windows.Forms.Cursors.Hand;
                        cb_1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                        cb_1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        cb_1.ForeColor = System.Drawing.Color.Black;
                        cb_1.FormattingEnabled = true;
                        cb_1.Margin = new System.Windows.Forms.Padding(0);
                        cb_1.Size = new System.Drawing.Size(128, 26);
                        cb_1.SelectedIndex = 0;
                        cb_1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbCycleResult1_DrawItem);

                        lbl_2 = new Label();
                        lbl_2.Text = periodtWin.ToString();
                        lbl_2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_2.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_2.Size = new System.Drawing.Size(53, 25);
                        lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        lbl_3 = new Label();
                        if (isWin == true)
                        {
                            lbl_3.Text = "中";
                            lbl_3.ForeColor = System.Drawing.Color.Red;
                            sumWin++;
                        }
                        else
                        {
                            lbl_3.Text = "挂";
                            lbl_3.ForeColor = System.Drawing.Color.Black;
                        }
                        lbl_3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        lbl_3.Padding = new System.Windows.Forms.Padding(20, 6, 20, 6);
                        lbl_3.Size = new System.Drawing.Size(60, 25);
                        lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        flowLayoutPanel1.Controls.Add(lbl_1);
                        flowLayoutPanel1.Controls.Add(cb_1);
                        flowLayoutPanel1.Controls.Add(lbl_2);
                        flowLayoutPanel1.Controls.Add(lbl_3);
                        LastBets += Convert.ToInt32(lbl_2.Text);
                    }


                    if (ckRegularCycle.Checked == true) //规律周期
                    {


                    }
                    else //中奖即进入下一周期
                    {

                    }
                    #endregion

                    #region 計算
                    //每期注數 共?元
                    lblBetsMoney.Text = (Convert.ToDecimal(lblBets.Text) * Convert.ToDecimal(cbMoney.SelectedItem.ToString().Replace("2元", "2").Replace("2角", "0.2").Replace("2分", "0.02").Replace("2厘", "0.002")) * Convert.ToDecimal(txtTimes.Text)).ToString(".###");
                    //目前下注?周期
                    lblCurrentBetsCycle.Text = (cycle_2 - 1).ToString();
                    //共下注?期
                    lblSumBetsCycle.Text = LastBets.ToString();
                    //總投注額?元
                    lblSumBetsMoney.Text = (Convert.ToDecimal(lblBetsMoney.Text) * Convert.ToDecimal(lblSumBetsCycle.Text)).ToString();
                    //獎金?元
                    lblWinMoney.Text = (Convert.ToDouble((Convert.ToDecimal(sumWin) * (Convert.ToDecimal(txtGameNum.Text)))) * 0.1).ToString();
                    //盈虧?元
                    lblProfit.Text = (Convert.ToDecimal(lblWinMoney.Text) - Convert.ToDecimal(lblSumBetsMoney.Text)).ToString();
                    //中奖率
                    double WinOpp = (sumWin * 100 / Convert.ToDouble(lblCurrentBetsCycle.Text));
                    lblPlanWinOpp.Text = WinOpp.ToString("0.00");
                    #endregion
                }
            }
            else if (cbGameKind.Text == "定位胆")
            {

            }

            rtxtPlanCycle.ReadOnly = true;//this
        }

        private void ConnectDbGetHistoryNumber()
        {
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";

            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = 4winform; Password=sasa";
            con = new SqlConnection(connetionString);
            string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            try
            {
                con.Open();
                string Sqlstr = @"SELECT issue as Issue, number as Number FROM HistoryNumber WHERE issue LIKE '" + date + "%' ORDER BY issue DESC";
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                var str_json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented);
                //MessageBox.Show("Connection Open ! ");
                JArray ja = (JArray)JsonConvert.DeserializeObject(str_json);
                //string ii = ja[0]["issue"].ToString();
                jArrHistoryNumber = ja;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void ConnectDbGetRandomNumber(string type, string PlanName)
        {
            string serverIP = "43.252.208.201, 1433\\SQLEXPRESS", DB = "lottery";
            string connetionString = null;
            SqlConnection con;
            connetionString = "Data Source=" + serverIP + ";Initial Catalog = " + DB + "; USER ID = 4winform; Password=sasa";
            con = new SqlConnection(connetionString);
            string date = DateTime.Now.ToString("u").Substring(0, 10).Replace("-", "");
            try
            {
                //todo 修改每種不同的號碼
                if (PlanName == "玉神计划")
                {
                    con.Open();
                    string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' ";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    NowAnalyzeNumber = dt.Rows[0]["Number"].ToString();
                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    //MessageBox.Show("Connection Open ! ");
                    JArray ja = (JArray)JsonConvert.DeserializeObject(str_json);
                    //string ii = ja[0]["issue"].ToString();
                    NowAnalyzeNumberArr = ja;
                }
                else if (PlanName == "幻影计划")
                {
                    con.Open();
                    string Sqlstr = @"SELECT [number] AS Number FROM 
(
SELECT ROW_NUMBER() OVER(ORDER BY [number]) NUM,
* FROM [RandomNumber]
WHERE date = '{0}' AND type = '{1}'
) A
WHERE NUM >40 AND NUM <81";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    NowAnalyzeNumber = dt.Rows[0]["Number"].ToString();
                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    //MessageBox.Show("Connection Open ! ");
                    JArray ja = (JArray)JsonConvert.DeserializeObject(str_json);
                    //string ii = ja[0]["issue"].ToString();
                    NowAnalyzeNumberArr = ja;
                }
                else
                {
                    con.Open();
                    string Sqlstr = @"SELECT [number] AS Number FROM 
(
SELECT ROW_NUMBER() OVER(ORDER BY [number]) NUM,
* FROM [RandomNumber]
WHERE date = '{0}' AND type = '{1}'
) A
WHERE NUM >40 AND NUM <80";
                    //string Sqlstr = @"SELECT top(40) number AS Number FROM RandomNumber WHERE date = '{0}' AND type = '{1}' order by NewID()";
                    SqlDataAdapter da = new SqlDataAdapter(string.Format(Sqlstr, date, type), con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    NowAnalyzeNumber = ds.Tables[0].Rows[2]["Number"].ToString();
                    da.Fill(ds);
                    //NowAnalyzeNumber = ds.Tables[0].Rows[0]["Number"].ToString();
                    DataTable dt = ds.Tables[0];

                    NowAnalyzeNumber = dt.Rows[0]["Number"].ToString();
                    var str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                    //MessageBox.Show("Connection Open ! ");
                    JArray ja = (JArray)JsonConvert.DeserializeObject(str_json);
                    //string ii = ja[0]["issue"].ToString();
                    NowAnalyzeNumberArr = ja;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void btnFiveNumberPhantomPlan_Click(object sender, EventArgs e)
        {
            ConnectDbGetHistoryNumber();

            #region 設定選項名稱
            cbGameKind.Text = "五星";

            cbGameDirect.Items.Clear();
            cbGameDirect.Items.Add("单式");
            cbGameDirect.Items.Add("复式");
            cbGameDirect.SelectedIndex = 0;
            cbGamePlus.Items.Clear();
            cbGamePlus.Items.Add("30000+");
            cbGamePlus.Items.Add("40000+");
            cbGamePlus.Items.Add("50000+");
            cbGamePlus.SelectedIndex = 0;

            cbGamePlan.Text = "幻影计划";//玉神计划幻影计划

            switch (cbGamePlus.SelectedItem.ToString().Substring(0, 1))
            {
                case "3":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("3", "三期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                default:
                    break;
            }

            //這次用三期一周
            cbGameCycle.SelectedIndex = 0;

            //用進入下一期
            ckWinToNextCycle.Checked = false;

            #endregion

            CountAndShow();
        }

        private void btnFiveNumberLightPlan_Click(object sender, EventArgs e)
        {
           

            ConnectDbGetHistoryNumber();

            #region 設定選項名稱
            cbGameKind.Text = "五星";

            cbGameDirect.Items.Clear();
            cbGameDirect.Items.Add("单式");
            cbGameDirect.Items.Add("复式");
            cbGameDirect.SelectedIndex = 0;
            cbGamePlus.Items.Clear();
            cbGamePlus.Items.Add("30000+");
            cbGamePlus.Items.Add("40000+");
            cbGamePlus.Items.Add("50000+");
            cbGamePlus.SelectedIndex = 0;

            cbGamePlan.Text = " 神灯计划";//玉神计划幻影计划神灯计划

            switch (cbGamePlus.SelectedItem.ToString().Substring(0, 1))
            {
                case "3":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("3", "三期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "4":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                case "5":
                    cbGameCycle.Items.Clear();
                    cbGameCycle.Items.Add(new ComboboxItem("2", "二期一周"));
                    cbGameCycle.Items.Add(new ComboboxItem("1", "一期一周"));
                    cbGameCycle.SelectedIndex = 0;
                    break;
                default:
                    break;
            }

            //這次用三期一周
            cbGameCycle.SelectedIndex = 0;

            //用進入下一期
            ckWinToNextCycle.Checked = false;

            #endregion

            CountAndShow();
        }

        private void txtGameNum_Leave_1(object sender, EventArgs e)
        {
            int Bouns = 0;
            if (txtGameNum.Text.Trim() != "")
            {
                Bouns = Int32.Parse(txtGameNum.Text.Trim());
                if (Bouns < 1700 || Bouns > 2000)
                {
                    MessageBox.Show("只能输入1700 ~ 2000的数字");
                    return;
                }
            }
        }
    }
}
