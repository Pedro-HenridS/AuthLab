

import { CadastroForm } from "../components/CadastroForm/CadastroForm";
import developerGirl from "../assets/pexels-divinetechygirl-1181467.jpg"
import styles from "./Register.module.css";

export function Register(){

    

    return (
    <div className={styles.page}>
        <section className={styles.whiteContainer}>
            <h1 className={styles.Title} >Criar conta</h1>
            <CadastroForm/>
        </section>
        
        <section className={styles.image_section}>
            <img className={styles.image} src={developerGirl} alt="Mão digitando no computador"/>
        </section>
    </div>
)}

