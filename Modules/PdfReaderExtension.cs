using iTextSharp.text.pdf;

namespace DiplomPrint.Modules
{
    public static class PdfReaderExtension
    {
        public static PdfDictionary GetFormFonts(this PdfReader reader)
        {
            var acroForm = (PdfDictionary)PdfReader.GetPdfObject(reader.Catalog.Get(PdfName.ACROFORM));
            var dr = acroForm.GetAsDict(PdfName.DR);
            return dr.GetAsDict(PdfName.FONT);
        }
    }
}
