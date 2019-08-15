import { UpdateCurrentUser, UpdateListing, CreateListing, UpdateStaff, CreateStaff } from './actionTypes'

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

export const updateStaff= (staff) => ({
    type: UpdateStaff,
    payload: staff
})

export const createStaff = () => ({
    type: CreateStaff,
    payload: {}
})