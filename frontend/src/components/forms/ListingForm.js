import React from 'react'
import { Form, Icon, Input, Select, Button, message } from 'antd'
import { connect } from 'react-redux'
import {updateListing} from '../../services/listingService'

const { TextArea } = Input
const { Option } = Select

const ListingForm = ({ ...props }) => {
    const { updateCurrentUser, listing } = props
    const handleSubmit = e => {
        e.preventDefault()
        props.form.validateFields((err, values) => {
            if (!err) {
                updateListing(listing.listingId, {...values,listingId:listing.listingId}).then(res=>{
                    props.saveUpdateListing()
                    message.success('Listing has updated')
                }).catch(err=>{
                    message.error('Update failed')
                })
              
            }
        })
    }

    const { getFieldDecorator } = props.form;
    return (
        <Form className="listing-form">
            <Form.Item>
                {getFieldDecorator('address', {
                    rules: [{ required: true, message: 'Please type listing address!' }],
                })(
                    <Input
                        placeholder="Address"
                    />,
                )}
            </Form.Item>
            <Form.Item>
                {getFieldDecorator('price', {
                    rules: [{ required: true, message: 'Please type listing price !' }],
                })(
                    <Input
                        type="number"
                        placeholder="price"
                    />,
                )}
            </Form.Item>
            <Form.Item>
                {getFieldDecorator('status', {
                    rules: [{ required: true, message: 'Please input your Password!' }],
                })(
                    <Select placeholder="Please select a status">
                        <Option value="open">Open</Option>
                        <Option value="underContract">Under contract</Option>
                        <Option value="withdrawn">Withdrawn</Option>
                    </Select>,
                )}
            </Form.Item>
            <Form.Item>
                {getFieldDecorator('confidentialNote')(
                     <Input
                     placeholder="confidentialNote"
                 />
                )}
                
            </Form.Item>
            <Form.Item>

                <Button
                    type='primary'
                    style={{ marginLeft: 8 }}
                    onClick={handleSubmit}
                > Submit </Button>

            </Form.Item>
        </Form>
    );

}

const mapStateToProps = (state, props) => {
    return {
        listing: state.listingReducer.listing
    }
}

const mapDispatchToProps = {

}

const WrappedListingForm = connect(
    mapStateToProps,
    mapDispatchToProps)(
        Form.create({
            name: 'listing_form',
            onFieldsChange(props, changedFields) {
                // props.onChange(changedFields)
            },
            mapPropsToFields(props) {
                return {
                    address: Form.createFormField({
                        ...props.listing.address,
                        value: props.listing.address
                    }),
                    price: Form.createFormField({
                        ...props.listing.price,
                        value: props.listing.price
                    }),
                    status: Form.createFormField({
                        ...props.listing.status,
                        value: props.listing.status
                    }),
                    confidentialNote: Form.createFormField({
                        ...props.listing.confidentialNote,
                        value: props.listing.confidentialNote
                    })

                }
            },
            onValuesChange(_, values) {
                console.log(values)
            }
        })(ListingForm)
    )

export default WrappedListingForm