package com.itesca.pryecto.Data.Repository;

import com.itesca.pryecto.Data.Entities.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User, Integer> {
    
}
