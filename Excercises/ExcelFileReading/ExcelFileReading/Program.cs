using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using GemBox.Spreadsheet;
using System.Linq;


namespace ExcelFileReading
{
    public class Movie
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
    }
    public class MovieEvaluator
    {
        public bool IsValid(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Title))
            {
                return false;
            }
            if (movie.Length < 60 || movie.Length > 400)
            {
                return false;
            }
            if (movie.ReleaseDate.Year < 1903)
            {
                return false;
            }
            return true;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string Name = "System.Int32";
            string fullName = "System.Nullable`1[[System_._Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]";
            if (Name.Equals("System.Int32"))
            {
                if (fullName.Contains("System.Int32"))
                {
                    Console.WriteLine("truw");
                }
            }
            //int? d = null;
            //var c = d ?? 0;
            //d = 10; 
            //var e = d ?? 0;
            //var f = d.Value;


            //var f = 10;
            //var s = 10;
            //Console.WriteLine("res: "+ f.CompareTo(s));

            //string f1 = "3,6";
            //string f2 = "3.6";
            //string f3 = "3";

            //float? v1 = float.Parse(f1.Replace(",", "."));
            //float? v2 = float.Parse(f2.Replace(",", "."));
            //float? v3 = float.Parse(f3.Replace(",", "."));

            //Console.WriteLine("v1 : "+ v1);
            //Console.WriteLine("v2 : " + v2);
            //Console.WriteLine("v3 : " + v3);

            GetAmountToSend();

            //S3FileFormatValues s = new S3FileFormatValues();
            //Console.WriteLine("val : " + s.AccountType);
            //var fileName = "ENC_1019_02_2020";
            ////var c = Program.ValidateFileName("ORI_1019_01_2020.txt");
            //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            //var splitted = fileNameWithoutExtension.Split('_');
            //var c = false;
            //if (splitted[0] == "ENC" && splitted[1] == "1019") {
            //    c = true;
            //};
            //Console.WriteLine(" name valid: "+c);

        }

        static void GetAmountToSend(int amount = 10000, int baseIntra = 12, float percentIntra = 12f, bool isSenderNatural = false)
        {
            float IVA = 19;
            float GMF = 0.4f;
            float senderGMF = 0;
            var Com = amount * (percentIntra / 100);
            var commision = baseIntra + Com;
            var VAT = commision * (IVA / 100);
            var total = amount + commision + VAT; //also reciever

            if (!isSenderNatural)
            {
                senderGMF = (GMF / 100) * total;
            }
            var senderTotal = senderGMF + total;

            var recieverTotal = amount - commision - VAT;

            Console.WriteLine("sender amount : " + senderTotal);
            Console.WriteLine("reciever amount : " + recieverTotal);
        }


        static bool ValidateFileName(string fileName)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var splitted = fileNameWithoutExtension.Split('_');
            if (splitted.Length == 4)
            {
                var month = Convert.ToInt32(splitted[2]);
                var year = Convert.ToInt32(splitted[3]);

                if (string.IsNullOrEmpty(fileName))
                    return false;
                if (string.IsNullOrEmpty(fileNameWithoutExtension))
                    return false;
                if (splitted.Length != 4)
                    return false;
                if (splitted[0] != "ORI")
                    return false;
                if (splitted[1] != "1019")
                    return false;
                if (splitted[2].Length != 2 || (month < 1 && month > 12))
                {
                    return false;
                }
                if (splitted[3].Length != 4 || (year < 0 && year > 9999))
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ReadTxtTabFile()
        {
            List<S3FileFormatValues> list = new List<S3FileFormatValues>();
            S3FileFormatValues item = new S3FileFormatValues();
            S3FileFormatHeader head = new S3FileFormatHeader();
            int i = 1;
            using (var reader = new StreamReader(@"C:\Users\HashMakerSol\Desktop\ORI_1019_01_2020.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = "13	60258745		Sastre	Moreno	David	Guillermo		Calle 36 cra 7 - 4 Piso 10	25	126	169	000000002197	5	9	1000	1000	1000	1000	1000	1000	1000	1000	1000	1000	1000	1000";

                    string sep = "\t";
                    var values = line.Split(sep.ToCharArray());

                    if (i == 1)
                    {
                        var s3fileHeader = new S3FileFormatHeader
                        {
                            DocumentType = values[0]?.ToString()?.Trim(),
                            CardNumber = values[1]?.ToString()?.Trim(),
                            DV = values[2]?.ToString()?.Trim(),
                            FirstHolderLastName = values[3]?.ToString()?.Trim(),
                            SecondHolderLastName = values[4]?.ToString()?.Trim(),
                            FirstHolderName = values[5]?.ToString()?.Trim(),
                            OtherHolderName = values[6]?.ToString()?.Trim(),
                            HolderBusinessName = values[7]?.ToString()?.Trim(),
                            Address = values[8]?.ToString()?.Trim(),
                            DepartmantCode = values[9]?.ToString()?.Trim(),
                            McpCode = values[10]?.ToString()?.Trim(),
                            Country = values[11]?.ToString()?.Trim(),
                            AccountNumber = values[12]?.ToString()?.Trim(),
                            AccountType = values[13]?.ToString()?.Trim(),
                            TaxExemptionCode = values[14]?.ToString()?.Trim(),
                            FinalAccountBalance = values[15]?.ToString()?.Trim(),
                            AverageDailyFinalBalance = values[16]?.ToString()?.Trim(),
                            MedianDailyAccountBalance = values[17]?.ToString()?.Trim(),
                            MaximumAccountBalanceValue = values[18]?.ToString()?.Trim(),
                            MinimumAccountBalanceValue = values[19]?.ToString()?.Trim(),
                            TotalValueOfCreditMovements = values[20]?.ToString()?.Trim(),
                            NumberOfMovementsOfCreditNature = values[21]?.ToString()?.Trim(),
                            AverageValueOfMovementsOfCreditNature = values[22]?.ToString()?.Trim(),
                            MedianInTheMonthOfDailyCreditNatureMovements = values[23]?.ToString()?.Trim(),
                            TotalValueOfMovementsOfDebitNature = values[24]?.ToString()?.Trim(),
                            NumberOfMovementsOfDebitNature = values[25]?.ToString()?.Trim(),
                            AveragevalueOfmovementsOfDebitNature = values[26]?.ToString()?.Trim()
                        };
                        head = s3fileHeader;
                    }
                    else
                    {
                        var s3fileformatvalues = new S3FileFormatValues
                        {
                            DocumentType = values[0] != "" ? Convert.ToInt32(values[0]) : 0,
                            CardNumber = values[1]?.ToString()?.Trim(),
                            DV = values[2] != "" ? Convert.ToInt32(values[2]) : 0,
                            FirstHolderLastName = values[3]?.ToString()?.Trim(),
                            SecondHolderLastName = values[4]?.ToString()?.Trim(),
                            FirstHolderName = values[5]?.ToString()?.Trim(),
                            OtherHolderName = values[6]?.ToString()?.Trim(),
                            HolderBusinessName = values[7]?.ToString()?.Trim(),
                            Address = values[8]?.ToString()?.Trim(),
                            DepartmantCode = values[9] != "" ? Convert.ToInt32(values[9]) : 0,
                            McpCode = values[10] != "" ? Convert.ToInt32(values[10]) : 0,
                            Country = values[11] != "" ? Convert.ToInt32(values[11]) : 0,
                            AccountNumber = values[12]?.ToString()?.Trim(),
                            AccountType = values[13] != "" ? Convert.ToInt32(values[13]) : 0,
                            TaxExemptionCode = values[14] != "" ? Convert.ToInt32(values[14]) : 0,
                            FinalAccountBalance = values[15] != "" ? Convert.ToInt32(values[15]) : 0,
                            AverageDailyFinalBalance = values[16] != "" ? Convert.ToInt32(values[16]) : 0,
                            MedianDailyAccountBalance = values[17] != "" ? Convert.ToInt32(values[17]) : 0,
                            MaximumAccountBalanceValue = values[18] != "" ? Convert.ToInt32(values[18]) : 0,
                            MinimumAccountBalanceValue = values[19] != "" ? Convert.ToInt32(values[19]) : 0,
                            TotalValueOfCreditMovements = values[20] != "" ? Convert.ToInt32(values[20]) : 0,
                            NumberOfMovementsOfCreditNature = values[21] != "" ? Convert.ToInt32(values[21]) : 0,
                            AverageValueOfMovementsOfCreditNature = values[22] != "" ? Convert.ToInt32(values[22]) : 0,
                            MedianInTheMonthOfDailyCreditNatureMovements = values[23] != "" ? Convert.ToInt32(values[23]) : 0,
                            TotalValueOfMovementsOfDebitNature = values[24] != "" ? Convert.ToInt32(values[24]) : 0,
                            NumberOfMovementsOfDebitNature = values[25] != "" ? Convert.ToInt32(values[25]) : 0,
                            AveragevalueOfmovementsOfDebitNature = values[26] != "" ? Convert.ToInt32(values[26]) : 0
                        };
                        list.Add(s3fileformatvalues);
                    }
                    i++;
                    Console.WriteLine();
                }
            }
        }
        static void ReadFromExcel()
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = ExcelFile.Load(@"C:\Users\HashMakerSol\Desktop\orignalFile.xlsx");

            var sb = new StringBuilder();

            List<S3FileFormatValues> list = new List<S3FileFormatValues>();
            S3FileFormatValues item = new S3FileFormatValues();

            // Iterate through all worksheets in an Excel workbook.
            foreach (var worksheet in workbook.Worksheets)
            {
                // Iterate through all rows in an Excel worksheet.
                foreach (var row in worksheet.Rows)
                {
                    if (Convert.ToInt32(row.ToString()) == 1)
                    {
                        continue;
                    }
                    Console.WriteLine();

                    //Console.WriteLine("first : "+ row.AllocatedCells[0].Value+ "   type : "+ row.AllocatedCells[0].ValueType);
                    //Console.WriteLine("last : " + row.AllocatedCells[26].Value + "   type : " + row.AllocatedCells[26].ValueType);

                    item.DocumentType = Convert.ToInt32(row.AllocatedCells[0].Value);

                    item.CardNumber = row.AllocatedCells[1].Value != null ? row.AllocatedCells[1].Value.ToString() : null;

                    item.DV = Convert.ToInt32(row.AllocatedCells[2].Value);

                    item.FirstHolderLastName = row.AllocatedCells[3].Value != null ? row.AllocatedCells[3].Value.ToString() : null;
                    item.SecondHolderLastName = row.AllocatedCells[4].Value != null ? row.AllocatedCells[4].Value.ToString() : null;
                    item.FirstHolderName = row.AllocatedCells[5].Value != null ? row.AllocatedCells[5].Value.ToString() : null;
                    item.OtherHolderName = row.AllocatedCells[6].Value != null ? row.AllocatedCells[6].Value.ToString() : null;
                    item.HolderBusinessName = row.AllocatedCells[7].Value != null ? row.AllocatedCells[7].Value.ToString() : null;
                    item.Address = row.AllocatedCells[8].Value != null ? row.AllocatedCells[8].Value.ToString() : null;

                    item.DepartmantCode = Convert.ToInt32(row.AllocatedCells[9].Value);
                    item.McpCode = Convert.ToInt32(row.AllocatedCells[10].Value);
                    item.Country = Convert.ToInt32(row.AllocatedCells[11].Value);

                    item.AccountNumber = row.AllocatedCells[12].Value != null ? row.AllocatedCells[12].Value.ToString() : null;

                    item.AccountType = Convert.ToInt32(row.AllocatedCells[13].Value);
                    item.TaxExemptionCode = Convert.ToInt32(row.AllocatedCells[14].Value);
                    item.FinalAccountBalance = Convert.ToInt32(row.AllocatedCells[15].Value);
                    item.AverageDailyFinalBalance = Convert.ToInt32(row.AllocatedCells[16].Value);
                    item.MedianDailyAccountBalance = Convert.ToInt32(row.AllocatedCells[17].Value);
                    item.MaximumAccountBalanceValue = Convert.ToInt32(row.AllocatedCells[18].Value);
                    item.MinimumAccountBalanceValue = Convert.ToInt32(row.AllocatedCells[19].Value);
                    item.TotalValueOfCreditMovements = Convert.ToInt32(row.AllocatedCells[20].Value);
                    item.NumberOfMovementsOfCreditNature = Convert.ToInt32(row.AllocatedCells[21].Value);
                    item.AverageValueOfMovementsOfCreditNature = Convert.ToInt32(row.AllocatedCells[22].Value);
                    item.MedianInTheMonthOfDailyCreditNatureMovements = Convert.ToInt32(row.AllocatedCells[23].Value);
                    item.TotalValueOfMovementsOfDebitNature = Convert.ToInt32(row.AllocatedCells[24].Value);
                    item.NumberOfMovementsOfDebitNature = Convert.ToInt32(row.AllocatedCells[25].Value);
                    item.AveragevalueOfmovementsOfDebitNature = Convert.ToInt32(row.AllocatedCells[26].Value);

                    list.Add(item);
                }
            }
            var lists = list;
        }
    }
    public class S3FileFormatValues
    {
        public int DocumentType { get; set; }
        public string CardNumber { get; set; }
        public int DV { get; set; }
        public string FirstHolderLastName { get; set; }
        public string SecondHolderLastName { get; set; }
        public string FirstHolderName { get; set; }
        public string OtherHolderName { get; set; }
        public string HolderBusinessName { get; set; }
        public string Address { get; set; }
        public int DepartmantCode { get; set; }
        public int McpCode { get; set; }
        public int Country { get; set; }
        public string AccountNumber { get; set; } //int
        public int AccountType { get; set; }
        public int TaxExemptionCode { get; set; }
        public int FinalAccountBalance { get; set; }
        public int AverageDailyFinalBalance { get; set; }
        public int MedianDailyAccountBalance { get; set; }
        public int MaximumAccountBalanceValue { get; set; }
        public int MinimumAccountBalanceValue { get; set; }
        public int TotalValueOfCreditMovements { get; set; }
        public int NumberOfMovementsOfCreditNature { get; set; }
        public int AverageValueOfMovementsOfCreditNature { get; set; }
        public int MedianInTheMonthOfDailyCreditNatureMovements { get; set; }
        public int TotalValueOfMovementsOfDebitNature { get; set; }
        public int NumberOfMovementsOfDebitNature { get; set; }
        public int AveragevalueOfmovementsOfDebitNature { get; set; }
    }

    public class S3FileFormatHeader
    {
        public string DocumentType { get; set; }
        public string CardNumber { get; set; }
        public string DV { get; set; }
        public string FirstHolderLastName { get; set; }
        public string SecondHolderLastName { get; set; }
        public string FirstHolderName { get; set; }
        public string OtherHolderName { get; set; }
        public string HolderBusinessName { get; set; }
        public string Address { get; set; }
        public string DepartmantCode { get; set; }
        public string McpCode { get; set; }
        public string Country { get; set; }
        public string AccountNumber { get; set; } //int
        public string AccountType { get; set; }
        public string TaxExemptionCode { get; set; }
        public string FinalAccountBalance { get; set; }
        public string AverageDailyFinalBalance { get; set; }
        public string MedianDailyAccountBalance { get; set; }
        public string MaximumAccountBalanceValue { get; set; }
        public string MinimumAccountBalanceValue { get; set; }
        public string TotalValueOfCreditMovements { get; set; }
        public string NumberOfMovementsOfCreditNature { get; set; }
        public string AverageValueOfMovementsOfCreditNature { get; set; }
        public string MedianInTheMonthOfDailyCreditNatureMovements { get; set; }
        public string TotalValueOfMovementsOfDebitNature { get; set; }
        public string NumberOfMovementsOfDebitNature { get; set; }
        public string AveragevalueOfmovementsOfDebitNature { get; set; }
    }
}
