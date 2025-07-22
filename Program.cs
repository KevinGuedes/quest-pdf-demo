// dotnet tool install QuestPDF.Previewer --global
// dotnet watch
// run both to preview the PDF in real time


using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;


Document.Create(container =>
{
    container.Page(page =>
    {
        page.Margin(50);
        page.Size(PageSizes.A4);
        page.DefaultTextStyle(x => x.FontSize(12));
        page.PageColor(Colors.White);

        page.Header()
            .Text("Sample PDF Document")
            .SemiBold()
            .FontSize(20)
            .FontColor(Colors.Blue.Darken2)
            .AlignCenter();

        page.Content()
            .PaddingVertical(30)
            .Column(column =>
            {
                column.Spacing(15);

                column.Item()
                    .Text("Hello, World!")
                    .SemiBold()
                    .FontColor(Colors.Blue.Medium)
                    .FontSize(30);

                column
                    .Item()
                    .Text("This is a sample PDF document created using QuestPDF.")
                    .FontColor(Color.FromRGB(2, 2, 2));

                column
                    .Item()
                    .Text("You can add more content here as needed.");
            });

        page.Content().Row(row =>
        {
            row.AutoItem()
                .Text("This is a row with auto width.")
                .FontColor(Colors.Green.Darken2);

            row.AutoItem()
                .Text("This is a row with auto width.")
                .FontColor(Colors.Green.Darken2);
        });

        page.Footer()
            .AlignCenter()
            .Text(text =>
            {
                text.Span("Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
});
}).ShowInCompanion();
//.ShowInPreviewer is now obsolete
// https://www.questpdf.com/