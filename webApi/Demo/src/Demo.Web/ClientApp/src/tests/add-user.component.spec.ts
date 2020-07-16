import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AddUserComponent } from '../app/user/add-user.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';

describe('AddUserComponent', () => {
  let component: AddUserComponent;
  let fixture: ComponentFixture<AddUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientTestingModule],
      providers: [
        { provide: 'BASE_URL'}
      ],
      declarations: [AddUserComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual(' Please enter your details below ');
  }));

  it('should start with an empty string for first name input field', async(() => {
    fixture.whenStable().then(() => {
      let element = fixture.nativeElement.querySelector('#firstName');
      expect(element.textContent).toBe('');
    })
  }));

  it('should start with an empty string for last name input field', async(() => {
    fixture.whenStable().then(() => {
      let element = fixture.nativeElement.querySelector('#lastName');
      expect(element.textContent).toBe('');
    })
  }));
})
