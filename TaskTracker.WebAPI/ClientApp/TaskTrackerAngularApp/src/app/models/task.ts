export class Task {
  id: string;
  title: string;
  description: string | null;
  status: string | null;
  dueDate: Date | null;

  constructor(id: string, title: string, description: string | null, status: string | null, dueDate: Date | null) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.status = status;
    this.dueDate = dueDate;
  }
}
