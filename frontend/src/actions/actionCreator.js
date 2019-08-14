import { UpdateCurrentUser, UpdateListing, CreateListing } from './actionTypes'

export const updateCurrentUser = (user) => ({
    type: UpdateCurrentUser,
    payload: user
})

export const updateListing = (listing) => ({
    type: UpdateListing,
    payload: listing
})

export const createListing = () => ({
    type: CreateListing,
    payload: {}
})