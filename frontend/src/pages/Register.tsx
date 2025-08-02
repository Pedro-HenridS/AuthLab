import { PasswordInput } from "../components/PasswordInput/PasswordInput";
import { InputComponent } from "../components/InputComponent/InputComponent";
import developerGirl from "../assets/pexels-divinetechygirl-1181467.jpg"
import styles from "./Register.module.css";

export function Register(){
    return (
    <div className={styles.page}>
        <form className={ styles.form }>
            <h1 className={styles.Title} >Criar conta</h1>
            <label className={styles.InputComponent}>
                <InputComponent  placeholder="Insira seu email"/>
            </label>
            <label className={styles.PasswordInput}>
                <PasswordInput/>
            </label>
        </form>

        <section className={styles.image_section}>
            <img className={styles.image} src={developerGirl} alt="Mão digitando no computador"/>
        </section>
    </div>
)}

