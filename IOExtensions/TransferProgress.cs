using System;

namespace IOExtensions
{
    public class TransferProgress
    {
        public TransferProgress(DateTime startedTimestamp, long bytesTransfered)
        {
            BytesTransferred = bytesTransfered;
            BytesPerSecond = BytesTransferred / DateTime.Now.Subtract(startedTimestamp).TotalSeconds;
        }

        public long Total { get; set; }

        public long Transferred { get; set; }

        public long BytesTransferred { get; set; }

        public long StreamSize { get; set; }

        public string ProcessedFile { get; set; }

        public double BytesPerSecond { get; }

        public double Fraction => BytesTransferred / (double)Total;

        public double Percentage => 100.0 * Fraction;


        public string GetTotalTransferedFormatted(SuffixStyle suffixStyle, int decimalPlaces)
        {
            return Helpers.ToSizeWithSuffix(Total, suffixStyle, decimalPlaces);
        }

        public string GetTotalTransferedFormatted(SuffixStyle suffixStyle, string format)
        {
            return Helpers.ToSizeWithSuffix(Total, suffixStyle, format);
        }

        public string GetBytesTransferedFormatted(SuffixStyle suffixStyle, int decimalPlaces)
        {
            return Helpers.ToSizeWithSuffix(BytesTransferred, suffixStyle, decimalPlaces);
        }

        public string GetBytesTransferedFormatted(SuffixStyle suffixStyle, string format)
        {
            return Helpers.ToSizeWithSuffix(BytesTransferred, suffixStyle, format);
        }

        public string GetDataPerSecondFormatted(SuffixStyle suffixStyle, int decimalPlaces)
        {
            return $"{Helpers.ToSizeWithSuffix((long) BytesPerSecond, suffixStyle, decimalPlaces)}/sec";
        }

        public string GetDataPerSecondFormatted(SuffixStyle suffixStyle, string format)
        {
            return $"{Helpers.ToSizeWithSuffix((long)BytesPerSecond, suffixStyle, format)}/sec";
        }

        public override string ToString()
        {
            return $"Total: {Total}, BytesTransferred: {BytesTransferred}, Percentage: {Percentage}";
        }

        public string ToStringFormatted(SuffixStyle style = SuffixStyle.Windows, string format = "{0:0.0}")
        {
            return $"Total: {GetTotalTransferedFormatted(style, format)}, BytesTransferred: {GetBytesTransferedFormatted(style, format)}, Percentage: {Percentage}";
        }

        public string ToStringFormatted(SuffixStyle style = SuffixStyle.Windows, int decimalPlaces = 1)
        {
            return $"Total: {GetTotalTransferedFormatted(style, decimalPlaces)}, BytesTransferred: {GetBytesTransferedFormatted(style, decimalPlaces)}, Percentage: {Percentage}";
        }
    }
}