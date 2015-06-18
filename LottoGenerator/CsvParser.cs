using System.Collections.Generic;
using System.IO;
using System.Linq;
using LINQtoCSV;

namespace LottoGenerator
{
    public class CsvParser<T> where T : class, new()
    {
        private readonly CsvFileDescription _csvFileDescription;
        private readonly CsvContext _csvContext;

        public CsvParser()
        {
            _csvFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true,
                MaximumNbrExceptions = 0
            };

            _csvContext = new CsvContext();
        }

        public List<T> Parse(string filename)
        {
            var records = _csvContext.Read<T>(filename, _csvFileDescription);
            return records.ToList();
        }

        public List<T> Parse(StreamReader streamReader)
        {
            var records = _csvContext.Read<T>(streamReader, _csvFileDescription);
            return records.ToList();
        }

        public List<T> ParseAndIgnoreCsvColumnHeaders(StreamReader streamReader)
        {
            _csvFileDescription.FirstLineHasColumnNames = true;
            var records = _csvContext.Read<T>(streamReader, _csvFileDescription);
            return records.ToList();
        }

        public List<T> ParseAndIgnoreCsvColumnHeaders(string filename)
        {
            _csvFileDescription.FirstLineHasColumnNames = true;
            var records = _csvContext.Read<T>(filename, _csvFileDescription);
            return records.ToList();
        }
    }
}
