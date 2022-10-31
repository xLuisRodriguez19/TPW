package com.itesca.pryecto.Controllers.User;

import com.itesca.pryecto.Controllers.User.UserService.UserService;
import com.itesca.pryecto.Data.Entities.User;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UserController {
    
    @Autowired
    private UserService _userService;

    @PostMapping("/user")
    public void addUser(@RequestBody User user){
        _userService.save(user);
    }


    @GetMapping("/users")
    public List<User> getUsers(){
        return _userService.listAll();
    }
}
