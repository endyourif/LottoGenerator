using LINQtoCSV;

namespace LottoGenerator.Models
{
    public class LottoNumbersCsv
    {
        [CsvColumn(Name = "DrawDate", FieldIndex = 1)]
        public string DrawDate { get; set; }

        [CsvColumn(Name = "Year", FieldIndex = 2)]
        public string Year { get; set; }

        [CsvColumn(Name = "Number1", FieldIndex = 3)]
        public string Number1 { get; set; }

        [CsvColumn(Name = "Number2", FieldIndex = 4)]
        public string Number2 { get; set; }

        [CsvColumn(Name = "Number3", FieldIndex = 5)]
        public string Number3 { get; set; }

        [CsvColumn(Name = "Number4", FieldIndex = 6)]
        public string Number4 { get; set; }

        [CsvColumn(Name = "Number5", FieldIndex = 7)]
        public string Number5 { get; set; }

        [CsvColumn(Name = "Number6", FieldIndex = 8)]
        public string Number6 { get; set; }

        [CsvColumn(Name = "Bonus", FieldIndex = 9)]
        public string Bonus { get; set; }
    }
}
