//
//  ViewController.swift
//  WelbornEdward_FridgePal
//
//  Created by Roy Welborn on 11/24/20.
//

import UIKit

class MainViewController: UIViewController {

    /* Variable Declarations */
    
    let nav = UINavigationItem()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        nav.title = "Welcome $User" // User will be the name of the user from the login screen
        
    }
}

/* TODO:
 
 Login Screen
 Add food to database
 remove food from database
 alert if food is older than xx days
 edit food in database
 ** optional food roulette based on main ingredients call reciperoulette.tv in another form??
 
 
 
 */

