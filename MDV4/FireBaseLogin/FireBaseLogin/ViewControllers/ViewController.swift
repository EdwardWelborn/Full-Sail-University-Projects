//
//  ViewController.swift
//  FireBaseLogin
//
//  Created by Roy Welborn on 12/3/20.
//

import UIKit

class ViewController: UIViewController {

    @IBOutlet weak var signUpButton: UIButton!
    @IBOutlet weak var loginButton: UIButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        setupElements()
    }

    func setupElements()
    {
        Utilities.styleFilledButton(loginButton)
        Utilities.styleFilledButton(signUpButton)
    }
}

