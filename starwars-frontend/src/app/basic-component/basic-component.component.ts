import { Component } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpParamsOptions,
} from '@angular/common/http';

@Component({
  selector: 'app-basic-component',
  templateUrl: './basic-component.component.html',
  styleUrls: ['./basic-component.component.css'],
})
export class BasicComponentComponent {
  response = 'a response';
  numbers = [1,2,3,4]
  isCheckboxDisabled = true;

  constructor(private http: HttpClient) {}

  isDisabled (number: number) {
    return number === 2
  }
  createPerson() {
    const postData = {
      name: 'John Doe',
      email: 'johndoe@example.com',
    };

    // Define the HTTP headers if needed (e.g., for authentication)
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    // Make the POST request
    this.http
      .post('https://jsonplaceholder.typicode.com/posts', postData, {
        headers,
      })
      .subscribe(
        (response: any) => {
          console.log('POST Request Successful:', response);
          this.response = JSON.stringify(response, null, 2);
          // Handle the response data here
        },
        (error) => {
          console.error('POST Request Error:', error);
          // Handle any errors here
        }
      );
  }
}
