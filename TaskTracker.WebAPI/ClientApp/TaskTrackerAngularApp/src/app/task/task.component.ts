import { Component } from '@angular/core';
import { Task } from '../models/task';
import { TaskService } from '../services/task.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  tasks: Task[] = [];
  postTaskForm: FormGroup;
  isPostTaskFormSubmitted: boolean = false;


  constructor(private taskService: TaskService) {
    this.postTaskForm = new FormGroup({
      title: new FormControl('', [Validators.required]),
      description: new FormControl(''),
      status: new FormControl(''),
      dueDate: new FormControl('')
    });
  }

  loadTasks() {
    this.taskService.getTasks()
      .subscribe({

        next: (response: Task[]) => {
          this.tasks = response;
        },

        error: (error: any) => {
          console.log(error)
        },

        complete: () => { }

      }
      );
  }
  ngOnInit() {
    console.log("Load Tasks");

   this.loadTasks();
  }


  get postTask_TitleNameControl(): any {
    return this.postTaskForm.controls['title'];
  };

  public postTaskSubmitted() {
    console.log("submitted");
    console.log(this.postTaskForm.value);
    this.taskService.postTasks(this.postTaskForm.value).subscribe({
      next: (response: Task) => {
        console.log(response);
        this.loadTasks();
        this.postTaskForm.reset();
      },
      error: (error: any) => {
        console.log(error) },
      complete: () => {
      }
    });
    this.isPostTaskFormSubmitted = true;
    this.postTaskForm.reset();
  }

}
