using Core.Contract;
using Core.Entities;
using Core.Interface;
using Core.UseCase.TransactionsHandler;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Spreadsheet.Services;

public class PdfGenerator : IPdfServices
{
    private readonly ITransactionsRepo _repo;
    public PdfGenerator(ITransactionsRepo repo)
    {
        _repo = repo;
    }

    public  async  Task<Byte[]> Pdf()
    {
        var id = new ProfileContract();
        var transactionPaged = await _repo.GetAll(id.Id);
        var transactions = transactionPaged.Data;
        
        Console.WriteLine($"Document : {transactions?.Count}");
        var doc = Document.Create(container =>
            container.Page
                (page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x=>x.FontSize(12));
                    
                    page.Header().Text("Relatório de gastos").FontSize(20).AlignCenter().Bold();
                    
                    page.Content().PaddingVertical(15).Table(table =>
                    {
                        table.ColumnsDefinition(definitionDescriptor =>
                        {
                            definitionDescriptor.ConstantColumn(50);
                            definitionDescriptor.RelativeColumn(4);
                            definitionDescriptor.RelativeColumn(3);
                            definitionDescriptor.RelativeColumn(4);
                        });
                        
                        table.Header(header =>
                        {
                            header.Cell().Text("Id").Bold();
                            header.Cell().Text("Tipo de Transação");
                            header.Cell().Text("Valor da Transação");
                            header.Cell().Text("Data");
                        });

                        if (transactions.Any())
                        {
                            foreach (var p in transactions)
                            {
                                table.Cell().Text(p.Id?.ToString() ?? "-");
                                table.Cell().Text(p.TransactionType.ToString());
                                table.Cell().Text($"{p.TransactionValue.Value}");
                                table.Cell().Text(p.SystemDate.Value.ToString("MM/dd/yyyy"));
                            }
                        }
                        else
                        {
                            table.Cell().ColumnSpan(4)
                                .AlignCenter()
                                .Text("Nenhuma transação encontrada")
                                .Italic();
                        }
                    });
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Pagina");
                        text.CurrentPageNumber();
                        text.Span("de ");
                        text.TotalPages();
                    });
                } ));

        
        return doc.GeneratePdf();
    }
}