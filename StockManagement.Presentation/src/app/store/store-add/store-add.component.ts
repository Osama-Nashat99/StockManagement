import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { StoreService } from '../../../services/store.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from '../../../models/User.model';
import { UserService } from '../../../services/user.service';
import { Store } from '../../../models/Store.model';

@Component({
  selector: 'app-store-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink],
  templateUrl: './store-add.component.html',
  styleUrl: './store-add.component.css'
})
export class StoreAddComponent implements OnInit {

  storeKeepers: User[] = [];

  constructor(private storeService: StoreService, private userService: UserService, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.userService.getAvailableStoreKeepers()
      .subscribe(storekeepers => {
        this.storeKeepers = storekeepers;
      })
  }

  createStoreForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(300)]),
    storeKeeperId: new FormControl("", Validators.required)
  });

  name = this.createStoreForm.controls['name'];
  storeKeeperId = this.createStoreForm.controls['storeKeeperId'];

  onCreateStore(){
    var store: Store = {
      id: 0,
      name: this.name.value,
      storeKeeperId: parseInt(this.storeKeeperId.value),
      storeKeeperName: ""
    }

    this.storeService.createStore(store)
          .subscribe(store => {
            if (store.id > 0){
              this.snackBar.open('Store has been created successfuly', 'Done', {
                duration: 3000
              });

              this.router.navigate(['/stores']);
            }
          });
  }
}
