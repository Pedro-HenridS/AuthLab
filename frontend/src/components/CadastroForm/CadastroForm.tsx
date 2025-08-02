import styles from "./CadastroForm.module.css"
import axios from 'axios';
import { useState } from "react";

export function CadastroForm(){
    const [formData, setFormData] = useState({
        name: "",
        email: "",
        password: ""
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
            const response = await axios.post('register', formData)
            console.log(response.data)
        }catch(err){
            console.log(err)
        }
    }

    return(
        <form className={ styles.form }>
                
                <input className={styles.input}  placeholder="Insira seu username" required value={formData.name} onChange={(e)=>{handleFormEdit(e, 'name')}}/>

                <input className={styles.input} placeholder="Insira seu email" required value={formData.email}  onChange={(e)=>{handleFormEdit(e, 'email')}}/>

                <input className={styles.input} type="password" placeholder="Insira sua senha" required value={formData.password}  onChange={(e)=>{handleFormEdit(e, 'password')}}/>

                <button className={styles.submit_button} type="submit" onClick={(e) => {handleForm(e)}}>Cadastrar</button>
        </form>
    )
}