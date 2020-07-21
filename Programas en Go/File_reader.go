package main

import (
    "fmt"
    "io/ioutil"
)
func main() {
    data, e := ioutil.ReadFile("himno.txt")
    if e != nil {
        fmt.Println("Error, e")
    return}
    fmt.Println(string(data))
}