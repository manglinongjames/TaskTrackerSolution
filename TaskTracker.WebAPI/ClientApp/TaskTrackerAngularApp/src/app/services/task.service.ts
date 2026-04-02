import { Injectable } from '@angular/core';
import { Task } from '../models/task';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'; // Import Observable for handling asynchronous data streams

const API_BASE_URL = "https://localhost:7221/api/"; // Base URL for the API
@Injectable({
  providedIn: 'root'
})
export class TaskService {
  tasks: Task[] = [];
  constructor(private httpClient: HttpClient) {
    //this.tasks = [
    //  new Task('1', 'Task 1', 'Description for Task 1', 'In Progress', new Date('2024-07-01')),
    //  new Task('2', 'Task 2', 'Description for Task 2', 'Completed', new Date('2024-07-05')),
    //]
  }

  public getTasks(): Observable<Task[]> {
    return this.httpClient.get<Task[]>(`${API_BASE_URL}tasks`);
  }

  public postTasks(task: Task): Observable<Task> {
    return this.httpClient.post<Task>(`${API_BASE_URL}tasks`,task);
  }
}
