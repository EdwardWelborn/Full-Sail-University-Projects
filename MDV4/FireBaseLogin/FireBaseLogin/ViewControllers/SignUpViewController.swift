//
//  SignUpViewController.swift
//  FireBaseLogin
//
//  Created by Roy Welborn on 12/3/20.
//

import UIKit
import FirebaseAuth

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
        (lastNameTextField.text?.trimmingCharacters(in: .whitespacesAndNewlines) == "")
        {
            return "Please Fill in ALL fields"
        }
        let cleanedPassword = passwordTextField.text!.trimmingCharacters(in: .whitespacesAndNewlines)
        
        if Utilities.isPasswordValid(cleanedPassword) == false
        {
            return "Please Make SURE your password is at least 8 characters, contains a special character and a number."
        }
        return ""
    }
    
    @IBAction func signUpButtonTapped(_ sender: UIButton)
    {
//        validate the fields
        let error = validateFields()
        if error != ""
        {
//            there is something wrong with the fields, show error message
            showError(error)
        }
        else
        {
//            Create the user
//            go to homescreen
            Auth.auth().createUser(withEmail: <#T##String#>, password: <#T##String#>) { (result, err) in
                <#code#>
            }
        }
//        create the new user
        
//        transition to home screen
    }
    
    func showError(_ message : String)
    {
        errorLabel.alpha = 1
        errorLabel.text = message
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
