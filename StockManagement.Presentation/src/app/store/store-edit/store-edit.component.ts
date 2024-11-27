import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { StoreService } from '../../../services/store.service';
import { UserService } from '../../../services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from '../../../models/User.model';
import { Store } from '../../../models/Store.model';
import { Role } from '../../../enums/role.enum';

@Component({
  selector: 'app-store-edit',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink],
  templateUrl: './store-edit.component.html',
  styleUrl: './store-edit.component.css'
})
export class StoreEditComponent {

  storeId: number = 0;
  storeKeepers: User[] = [];

  constructor(private storeService: StoreService, private userService: UserService, private route: ActivatedRoute, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.storeId = this.route.snapshot.params['id'];

    this.userService.getAvailableStoreKeepers()
      .subscribe(storekeepers => {
        this.storeKeepers = storekeepers;
      })

    this.storeService.getStore(this.storeId)
      .subscribe(store => {
        this.name.setValue(store.name);
        this.storeKeeperId.setValue(store.storeKeeperId);

        var storeKeeper: User = {
          id: store.storeKeeperId,
          username: store.storeKeeperName,
          firstName: "",
          lastName: "",
          role: Role.Store_Keeper
        };

        console.log(storeKeeper);

        this.storeKeepers.push(storeKeeper);
      })
  }

  updateStoreForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(300)]),
    storeKeeperId: new FormControl("", Validators.required)
  });

  name = this.updateStoreForm.controls['name'];
  storeKeeperId = this.updateStoreForm.controls['storeKeeperId'];

  onUpdateStore(){
    const formValues = this.updateStoreForm.value;

    var store: Store = {
      id: this.storeId,
      name: formValues.name,
      storeKeeperId: parseInt(formValues.storeKeeperId),
      storeKeeperName: ""
    };


    this.storeService.updateStore(this.storeId, store).subscribe(res => {
      this.snackBar.open('Store has been updated successfuly', 'Done', {
        duration: 3000
      });

      this.router.navigate(['/stores']);
    })
  }

}
