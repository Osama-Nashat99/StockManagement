import { Component, Input } from '@angular/core';
import * as XLSX from 'xlsx';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-export-to-excel',
  standalone: true,
  imports: [],
  templateUrl: './export-to-excel.component.html',
  styleUrl: './export-to-excel.component.css'
})
export class ExportToExcelComponent {
  @Input() items: any[] = [];
  @Input() title: string = '';

  exportToExcel(): void {
    const worksheet = XLSX.utils.json_to_sheet(this.items);
    const workbook = XLSX.utils.book_new();

    XLSX.utils.book_append_sheet(workbook, worksheet, this.title);

    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });

    this.saveAsExcelFile(excelBuffer, this.title);
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], { type: 'application/octet-stream' });
    saveAs(data, `${fileName}.xlsx`);
  }
}
