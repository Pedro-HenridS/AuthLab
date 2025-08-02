import styles from "./CadastroForm.module.css"
import axios from 'axios';
import { useState } from "react";

export function CadastroForm(){
    const [formData, setFormData] = useState({
        UserName: "",
        Email: "",
        Password: ""
    })

    const handleFormEdit= (event: React.ChangeEvent<HTMLInputElement>, name: string)=>{
        setFormData({
            ...formData,
            [name]: event.target.value
        })
    }

    const handleForm = async (event: React.MouseEvent<HTMLButtonElement>) => {
        try{
            event.preventDefault()
            console.log("Dados enviados", formData)
            const response = await axios.post('https://localhost:7063/Account/register', formData)
            console.log(response.data)
        }catch(err){
            console.log(formData)
            console.log(err)
        }
    }

    return(
        <form className={ styles.form }>
                
                <input className={styles.input}  placeholder="Insira seu username" value={formData.UserName} onChange={(e)=>{handleFormEdit(e, 'UserName')}}/>

                <input className={styles.input} placeholder="Insira seu email"  value={formData.Email}  onChange={(e)=>{handleFormEdit(e, 'Email')}}/>

                <input className={styles.input} type="password" placeholder="Insira sua senha"  value={formData.Password}  onChange={(e)=>{handleFormEdit(e, 'Password')}}/>

                <button className={styles.submit_button} type="submit" onClick={(e) => {handleForm(e)}}>Cadastrar</button>
        </form>
    )
}