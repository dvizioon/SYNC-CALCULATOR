using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ESSAS SAO AS BIBLIOTECAS QUE DEVEREMOS ADICIONAR EM NOSSO PROJETO
using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS

using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENÇÕES
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharpFont = iTextSharp.text.Font;
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)

namespace Calculadora_C_.Pdf_Genarate
{
    partial class PDF
    {
        public PDF(string nomePdf, string conteudoPdf, string caminhoPdf)
        {
            // Criar um novo documento PDF
            Document doc = new Document(PageSize.A4);

            try
            {
                // Criar uma nova instância do PdfWriter
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(caminhoPdf), FileMode.Create));

                // Abrir o documento
                doc.Open();

                // Adicionar o título ao documento com uma fonte específica
                doc.Add(new Paragraph("Compartilhando Saúde", new iTextSharpFont(iTextSharpFont.FontFamily.HELVETICA, 24f, iTextSharpFont.BOLD)));

                // Adicionar o conteúdo ao documento
                doc.Add(new Paragraph(conteudoPdf));
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            finally
            {
                // Fechar o documento
                if (doc != null && doc.IsOpen())
                {
                    doc.Close();
                }
            }
        }
    }
}