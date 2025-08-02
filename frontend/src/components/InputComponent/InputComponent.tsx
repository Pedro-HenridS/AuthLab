import styles from './InputComponent.module.css'
import type { IInputProps } from '../../Interfaces/IInputProps'

export function InputComponent({placeholder}:IInputProps){
    return(
        <input className={styles.input} placeholder={placeholder}/>
    )}