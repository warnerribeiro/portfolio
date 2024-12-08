const validatorMessage = function (atributo) {
    return `A propriedade '${atributo}' é invalida.`
}

const notExist = function (atributo) {
    return `${atributo} não existe.`
}

module.exports = {
    validatorMessage: validatorMessage,
    notExist: notExist,
}