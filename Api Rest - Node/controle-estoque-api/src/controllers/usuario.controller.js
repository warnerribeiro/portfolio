const usuarioService = require('../services/usuario.service');
const { validationResult } = require('express-validator');

const createError = require('http-errors');

const criar = async function (req, res, next) {
    try {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            throw createError(422, { errors: errors.array() });
        }

        const response = await usuarioService.criar(req.body);

        if (response && response.message) {
            throw response;
        }

        res.send(response);
    } catch (error) {
        return next(error);
    }

}

const atualizar = async function (req, res, next) {
    try {
        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            throw createError(422, { errors: errors.array() })
        }

        const response = await usuarioService.atualizar({
            nome: req.body.nome
        }, req.params.id);

        if (response && response.message) {
            throw response;
        }

        res.send(response);

    } catch (error) {
        return next(error);
    }
}

const encontrarTodos = async function (req, res, next) {
    try {
        const response = await usuarioService.encontrarTodos();
        res.send(response);
    } catch (error) {
        return next(error);
    }
}

const encontrarPorId = async function (req, res, next) {
    try {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            throw createErrors(422, { errors: errors.array() });
        }

        const response = await usuarioService.encontrarPorId(req.params.id);

        if (response && response.message) {
            throw response;
        }

        res.send(response);
    } catch (error) {
        return next(error);
    }
}

const login = async function(req, res, next){
    try {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            throw createErrors(422, { errors: errors.array() });
        }

        const response = await usuarioService.login(req.body);

        if (response && response.message) {
            throw response;
        }

        res.send(response);
    } catch (error) {
        return next(error);
    }
}

const deletar = async function (req, res, next) {
    try {

        const errors = validationResult(req);

        if (!errors.isEmpty()) {
            throw createErrors(422, { errors: errors.array() });
        }

        const response = await usuarioService.deletar(req.params.id);

        if (response && response.message) {
            throw response;
        }

        res.send(response);
    } catch (error) {
        return next(error);
    }
}

module.exports = {
    criar: criar,
    encontrarTodos, encontrarTodos,
    encontrarPorId, encontrarPorId,
    atualizar: atualizar,
    deletar: deletar,
    login: login,
}