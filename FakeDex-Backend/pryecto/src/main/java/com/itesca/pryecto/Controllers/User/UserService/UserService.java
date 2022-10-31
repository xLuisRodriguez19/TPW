package com.itesca.pryecto.Controllers.User.UserService;

import com.itesca.pryecto.Data.Entities.User;
import com.itesca.pryecto.Data.Repository.UserRepository;
import java.util.List;
 
import javax.transaction.Transactional;
 
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
@Transactional
public class UserService {
    @Autowired
    private UserRepository _context;
     
    public List<User> listAll() {
        return _context.findAll();
    }
     
    public void save(User user) {
        _context.save(user);
    }
     
    public User get(Integer id) {
        return _context.findById(id).get();
    }
     
    public void delete(Integer id) {
        _context.deleteById(id);
    }
}
