import { UpdateCurrentUser } from './actionTypes'

export const updateCurrentUser = (user) => ({
    type: UpdateCurrentUser,
    payload: user
})
