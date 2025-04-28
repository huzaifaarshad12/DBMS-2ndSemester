/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author HAMMAD TRADERS
 */
import java.sql.*;
import javax.swing.JOptionPane;
public class JavaConnect {
    Connection conn=null;
    public static Connection connectDb(){
        try{
            Class.forName("org.sqlite.JDBC");
            Connection conn =DriverManager.getConnection("jdbc:sqlite:D:\\MCS 2\\OOPs projects\\Banking_Managment_System\\Bank.db");
            return conn;
        }
        catch(Exception e){
          JOptionPane.showMessageDialog(null,e);  
          
        }
        return null;
    }
}
