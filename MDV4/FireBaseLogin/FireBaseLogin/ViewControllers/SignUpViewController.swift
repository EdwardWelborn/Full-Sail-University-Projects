//
//  SignUpViewController.swift
//  FireBaseLogin
//
//  Created by Roy Welborn on 12/3/20.
//

import UIKit

class SignUpViewController: UIViewController {

    
    @IBOutlet weak var errorLabel: UILabel!
    @IBOutlet weak var signUpButton: UIButton!
    @IBOutlet weak var firstNameTextField: UITextField!
    @IBOutlet weak var lastNameTextField: UITextField!
    @IBOutlet weak var emailAddressTextField: UITextField!
    @IBOutlet weak var passwordTextField: UITextField!
    
    
//    validate the fields and validate that the data is correct.
//    if everything is correct, return nil
//    otherwise return and error message
    func validateFields() -> String
    {
//        check that all fields are checked in
        if (firstNameTextField.text?.trimmingCharacters(in: .whitespacesAndNewlines) == "") ||
        (lastNameTextField.text?.trimmingCharacters(in: .whitespacesAndNewlines) == "") ||
        
        {
            return "Please Fill in ALL fields"
        }
        
        return ""
    }
    
    @IBAction func signUpButtonTapped(_ sender: UIButton)
    {
//        validate the fields
        
//        create the new user
        
//        transition to home screen
    }
    
    override func viewDidLoad()
    {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
        setupElements()
    }
    

    func setupElements()
    {
        errorLabel.alpha = 0
        
        Utilities.styleTextField(firstNameTextField)
        Utilities.styleTextField(lastNameTextField)
        Utilities.styleTextField(emailAddressTextField)
        Utilities.styleTextField(passwordTextField)
        Utilities.styleFilledButton(signUpButton)
    }
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
