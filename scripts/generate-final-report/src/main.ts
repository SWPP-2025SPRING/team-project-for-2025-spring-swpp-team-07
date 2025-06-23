import { watch } from "node:fs";
import path from "node:path";
import { mdToPdf } from "md-to-pdf";

const filename = `SWPP_team07_final`;
const outputFolderName = "output";
const rootDirectory = path.resolve(import.meta.dirname, "../../..");
const sprintDirectory = path.resolve(rootDirectory, `reports/final`);
const outputDirectory = path.resolve(sprintDirectory, outputFolderName);
const reportMarkdownPath = path.resolve(sprintDirectory, "README.md");

const run = async () => {
  const pdf = await mdToPdf(
    { path: reportMarkdownPath },
    {
      css: "h1 { page-break-before: always; } * { word-break: keep-all; line-height: 2; } @page { margin: 2cm 1.5cm; }",
      pdf_options: {
        format: "A4",
      },
    },
  );

  const pdfPath = path.resolve(outputDirectory, `${filename}.pdf`);
  await Bun.file(pdfPath).write(pdf.content);
};

await run();

const watcher = watch(
  sprintDirectory,
  { recursive: true },
  async (_, changedFilename) => {
    if (!changedFilename || changedFilename.startsWith(outputFolderName))
      return;

    await run();
  },
);

process.on("SIGINT", () => {
  watcher.close();
  process.exit(0);
});
